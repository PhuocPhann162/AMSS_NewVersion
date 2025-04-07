using AMSS.Dto.Requests.Suppliers;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Suppliers;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface ISupplierService
    {
        Task<APIResponse<PaginationResponse<GetSuppliersResponse>>> GetSuppliersAsync(GetSuppliersRequest request);
        Task<APIResponse<GetSupplierResponse>> GetSupplierByIdAsync(Guid id);
        Task<APIResponse<Guid>> CreateSupplierAsync(CreateSupplierRequest request);
        Task<APIResponse<bool>> UpdateSupplierAsync(Guid id, UpdateSupplierRequest request);
    }
}
