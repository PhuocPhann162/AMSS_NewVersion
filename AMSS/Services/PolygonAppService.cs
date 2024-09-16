using AMSS.Models;
using AMSS.Models.Dto.Polygon;
using AMSS.Models.Polygon;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using System.Net;

namespace AMSS.Services
{
    public class PolygonAppService : BaseService, IPolygonAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PolygonAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<APIResponse<IEnumerable<PolygonDto>>> GetAllPolygonsAsync()
        {
            try
            {
                IEnumerable<PolygonApp> lstPolygon = await _unitOfWork.PolygonAppRepository.GetAllAsync();
                var lstPolygonDto = _mapper.Map<IEnumerable<PolygonDto>>(lstPolygon);
                return BuildSuccessResponseMessage(lstPolygonDto, "Get all PolygonApps successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<IEnumerable<PolygonDto>>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<PolygonDto>> CreatePolygonAsync(CreatePolygonDto createPolygonDto)
        {
            try
            {
                var newPolygon = _mapper.Map<PolygonApp>(createPolygonDto);


                await _unitOfWork.PolygonAppRepository.CreateAsync(newPolygon);

                _unitOfWork.SaveAsync();

                return BuildSuccessResponseMessage(_mapper.Map<PolygonDto>(newPolygon), "PolygonApp was created successfully", HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<PolygonDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }


        public async Task<APIResponse<PolygonDto>> UpdatePolygonAsync(UpdatePolygonDto updatePolygonDto)
        {
            try
            {
                var newPolygon = _mapper.Map<PolygonApp>(updatePolygonDto);
                var result = await _unitOfWork.PolygonAppRepository.Update(newPolygon);
                _unitOfWork.SaveAsync();

                return BuildSuccessResponseMessage(_mapper.Map<PolygonDto>(newPolygon), "PolygonApp was updated successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<PolygonDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }
    }
}
