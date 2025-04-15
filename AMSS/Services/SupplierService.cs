using AMSS.Dto.Requests.Suppliers;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Suppliers;
using AMSS.Entities;
using AMSS.Models;
using AMSS.Models.Suppliers;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
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

            if (!string.IsNullOrEmpty(request.OrderBy) &&
                string.Equals(request.OrderBy, "CreatedAt", StringComparison.OrdinalIgnoreCase))
            {
                var sortExpression = new SortExpression<Supplier>(p => p.CreatedAt, request.OrderByDirection);
                sortExpressions.Add(sortExpression);
            }

            var suppliersPaginationResult = await _unitOfWork.SupplierRepository.GetAsync(x => x.SupplierRole == request.SupplierRole, request.CurrentPage, request.Limit, sortExpressions.ToArray());
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

        public async Task<APIResponse<GetSupplierResponse>> GetSupplierByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BuildErrorResponseMessage<GetSupplierResponse>("Not valid ID supplier", HttpStatusCode.BadRequest);
            }

            var supplier = await _unitOfWork.SupplierRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (supplier == null)
            {
                return BuildErrorResponseMessage<GetSupplierResponse>("Not found this supplier", HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<GetSupplierResponse>(supplier);

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
            await _unitOfWork.SupplierRepository.CreateAsync(newSupplier);
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
    }
}
