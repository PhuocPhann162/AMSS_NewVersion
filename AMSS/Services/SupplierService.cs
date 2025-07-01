using AMSS.Dto.Crop;
using AMSS.Dto.Requests.Suppliers;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Suppliers;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Models;
using AMSS.Models.Suppliers;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using System.Linq.Expressions;
using System.Net;

namespace AMSS.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<APIResponse<PaginationResponse<GetSuppliersResponse>>> GetSuppliersAsync(GetSuppliersRequest request)
        {
            var sortExpressions = new List<SortExpression<Supplier>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<Supplier, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
                ["Name"] = x => x.Name,
                ["ContactName"] = x => x.ContactName,
                ["ProvinceName"] = x => x.ProvinceName,
            };

            // Sort
            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<Supplier>(sortField, request.OrderByDirection));
            }

            // Filter and Search
            Expression<Func<Supplier, bool>> filter = x =>
                    x.SupplierRole == request.SupplierRole &&
                    (request.CountryCodes == null || request.CountryCodes.Count() == 0 || request.CountryCodes.Contains(x.CountryCode)) &&
                    (string.IsNullOrEmpty(request.Search) || x.Name.Contains(request.Search) || x.ContactName.Contains(request.Search));

            var suppliersPaginationResult = await _unitOfWork.SupplierRepository.GetAsync(
                filter,
                request.CurrentPage,
                request.Limit,
                sortExpressions.ToArray());
            var response = new PaginationResponse<GetSuppliersResponse>(suppliersPaginationResult.CurrentPage, suppliersPaginationResult.Limit,
                            suppliersPaginationResult.TotalRow, suppliersPaginationResult.TotalPage)
            {
                Collection = suppliersPaginationResult.Data.Select(x => new GetSuppliersResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    ContactName = x.ContactName,
                    CountryCode = x.CountryCode,
                    CountryName = x.CountryName,
                    ProvinceCode = x.ProvinceCode,
                    ProvinceName = x.ProvinceName,
                    Address = x.Address,
                    Email = x.Email,
                    PhoneCode = x.PhoneCode,
                    PhoneNumber = x.PhoneNumber,
                    CreatedAt = x.CreatedAt
                })
            };
            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<GetSuppliersByRoleResponse>> GetSupplierByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<GetSuppliersByRoleResponse>("Not valid ID supplier", HttpStatusCode.BadRequest);
            }

            var supplier = await _unitOfWork.SupplierRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (supplier == null)
            {
                return BuildErrorResponseMessage<GetSuppliersByRoleResponse>("Not found this supplier", HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<GetSuppliersByRoleResponse>(supplier);

            return BuildSuccessResponseMessage(response, "Get supplier by ID successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<Guid>> CreateSupplierAsync(CreateSupplierRequest request)
        {
            var supplierWithEmail = await _unitOfWork.SupplierRepository.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (supplierWithEmail is not null)
            {
                return BuildErrorResponseMessage<Guid>("Supplier was already existed", HttpStatusCode.Conflict);
            }
            var newSupplier = new Supplier(request);
            await _unitOfWork.SupplierRepository.AddAsync(newSupplier);
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(newSupplier.Id, "Supplier created successfully", HttpStatusCode.Created);
        }

        public async Task<APIResponse<bool>> UpdateSupplierAsync(Guid id, UpdateSupplierRequest request)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<bool>("Not valid ID supplier", HttpStatusCode.BadRequest);
            }
            var supplier = await _unitOfWork.SupplierRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (supplier == null)
            {
                return BuildErrorResponseMessage<bool>("Not found this supplier", HttpStatusCode.NotFound);
            }
            supplier.Update(request);
            await _unitOfWork.SaveChangeAsync();
            return BuildSuccessResponseMessage(true, "Supplier updated successfully", HttpStatusCode.OK);
        }

        public async Task<APIResponse<IEnumerable<GetSuppliersByRoleResponse>>> GetSuppliersByRoleAsync(Role role)
        {
            if (role is not Role.SUPPLIER_CROP && role is not Role.OWNER_FARM && role is not Role.SUPPLIER_COMMODITY)
            {
                return BuildErrorResponseMessage<IEnumerable<GetSuppliersByRoleResponse>>("Not valid role supplier", HttpStatusCode.BadRequest);
            }

            var supplierByRoles = await _unitOfWork.SupplierRepository.GetRESAsync(x => x.SupplierRole == role);
            var response = supplierByRoles.Select(s => new GetSuppliersByRoleResponse
            {
                SupplierId = s.Id,
                ContactName = s.ContactName,
                CompanyName = s.Name
            });

            return BuildSuccessResponseMessage(response);
        }

        public async Task<APIResponse<PaginationResponse<CropDto>>> GetCropsBySuppliersAsync(Guid supplierId, GetCropsBySupplierRequest request)
        {
            var supplier = await _unitOfWork.SupplierRepository.GetByIdAsync(supplierId);
            if (supplier is null)
            {
                return BuildErrorResponseMessage<PaginationResponse<CropDto>>("Not valid ID supplier", HttpStatusCode.BadRequest);
            }

            var sortExpressions = new List<SortExpression<Crop>>();

            var sortFieldMap = new Dictionary<string, Expression<Func<Crop, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                ["CreatedAt"] = x => x.CreatedAt,
                ["Name"] = x => x.Name,
            };

            if (!string.IsNullOrEmpty(request.OrderBy) && sortFieldMap.TryGetValue(request.OrderBy, out var sortField))
            {
                sortExpressions.Add(new SortExpression<Crop>(sortField, request.OrderByDirection));
            }

            Expression<Func<Crop, bool>> filter = x =>
                   (x.SupplierId == supplierId) &&
                   (string.IsNullOrEmpty(request.Search) || x.Name.Contains(request.Search));

            var cropsPaginationResult = await _unitOfWork.CropRepository.GetAsync(
                filter,
                request.CurrentPage, request.Limit,
                sortExpressions.ToArray());
            var response = new PaginationResponse<CropDto>(cropsPaginationResult.CurrentPage, cropsPaginationResult.Limit,
                            cropsPaginationResult.TotalRow, cropsPaginationResult.TotalPage)
            {
                Collection = cropsPaginationResult.Data.Select(x => new CropDto
                {
                    Id = x.Id,
                    Icon = x.Icon,
                    Name = x.Name,
                    Cycle = x.Cycle,
                    Edible = x.Edible,
                    Soil = x.Soil,
                    Watering = x.Watering,
                    Maintenance = x.Maintenance,
                    HardinessZone = x.HardinessZone,
                    Indoor = x.Indoor,
                    Propagation = x.Propagation,
                    CareLevel = x.CareLevel,
                    GrowthRate = x.GrowthRate,
                    Description = x.Description,
                    CultivatedArea = x.CultivatedArea,
                    PlantedDate = x.PlantedDate,
                    ExpectedDate= x.ExpectedDate,
                    Quantity = x.Quantity
                })
            };

            return BuildSuccessResponseMessage(response);
        }
    }
}
