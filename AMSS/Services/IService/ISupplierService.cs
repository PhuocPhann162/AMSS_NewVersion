using AMSS.Dto.Crop;
using AMSS.Dto.Requests.Suppliers;
using AMSS.Dto.Responses;
using AMSS.Dto.Responses.Suppliers;
using AMSS.Entities;
using AMSS.Enums;

namespace AMSS.Services.IService
{
    public interface ISupplierService
    {
        Task<APIResponse<PaginationResponse<GetSuppliersResponse>>> GetSuppliersAsync(GetSuppliersRequest request);

        Task<APIResponse<GetSuppliersByRoleResponse>> GetSupplierByIdAsync(Guid id);

        Task<APIResponse<IEnumerable<GetSuppliersByRoleResponse>>> GetSuppliersByRoleAsync(Role role);
        
        Task<APIResponse<Guid>> CreateSupplierAsync(CreateSupplierRequest request);

        Task<APIResponse<bool>> UpdateSupplierAsync(Guid id, UpdateSupplierRequest request);

        Task<APIResponse<PaginationResponse<CropDto>>> GetCropsBySuppliersAsync(Guid supplierId, GetCropsBySupplierRequest request);
    }
}
