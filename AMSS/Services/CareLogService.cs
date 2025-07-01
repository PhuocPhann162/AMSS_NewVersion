using AMSS.Dto.CareLog;
using AMSS.Dto.Requests.CareLogs;
using AMSS.Dto.Responses;
using AMSS.Entities;
using AMSS.Entities.CareLogs;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using System.Linq.Expressions;
using System.Net;
using AMSS.Enums;
using AutoMapper;
using AMSS.Dto.User;
using AMSS.Dto.Crop;
using AMSS.Dto.Field;

namespace AMSS.Services
{
    public class CareLogService : BaseService, ICareLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CareLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<APIResponse<bool>> CreateCareLogAsync(Guid userId, CreateCareLogRequest request)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId.ToString());
            if(user is null)
            {
                return BuildErrorResponseMessage<bool>("Not found this user", HttpStatusCode.BadRequest);
            }

            var newCareLog = new CareLog(request, userId);
            await _unitOfWork.CareLogRepository.AddAsync(newCareLog);
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true, "Care Log created successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<PaginationResponse<CareLogDto>>> GetCareLogsAsync(Guid userId, GetCareLogsRequest request)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            if (user is null)
            {
                return BuildErrorResponseMessage<PaginationResponse<CareLogDto>>("Not valid ID supplier", HttpStatusCode.BadRequest);
            }

            var sortExpressions = new List<SortExpression<CareLog>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<CareLog, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
            };

            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<CareLog>(sortField, request.OrderByDirection));
            }

            Expression<Func<CareLog, bool>> filter;
            if (user.Role is Role.ADMIN)
            {
                filter = x =>
                   (string.IsNullOrEmpty(request.Search) || x.Description.Contains(request.Search));
            }
            else
            {
                filter = x =>
                   (x.CreatedById == userId.ToString()) &&
                   (string.IsNullOrEmpty(request.Search) || x.Description.Contains(request.Search));
            }

            var careLogsPaginationResult = await _unitOfWork.CareLogRepository.GetPaginationIncludeAsync(
                filter,
                request.CurrentPage, request.Limit,
                sortExpressions.ToArray(),
                includes: [x => x.Crop, x => x.Field, x => x.CreatedBy]);

            var response = new PaginationResponse<CareLogDto>(careLogsPaginationResult.CurrentPage, careLogsPaginationResult.Limit,
                            careLogsPaginationResult.TotalRow, careLogsPaginationResult.TotalPage)
            {
                Collection = careLogsPaginationResult.Data.Select(x => new CareLogDto
                {
                    Id = x.Id,
                    Type = x.Type,
                    Description = x.Description,
                    Date = x.Date,
                    CropId = x.CropId,
                    FieldId = x.FieldId,
                    CreatedById = x.CreatedById,
                    Crop = _mapper.Map<CropDto>(x.Crop),
                    Field = _mapper.Map<FieldDto>(x.Field),
                    CreatedBy =  _mapper.Map<UserDto>(x.CreatedBy), 
                })
            };

            return BuildSuccessResponseMessage(response);
        }
    }
}
