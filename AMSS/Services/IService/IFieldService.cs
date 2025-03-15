using AMSS.Dto.Field;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface IFieldService
    {
        Task<APIResponse<IEnumerable<FieldDto>>> GetAllFieldsAsync(string? searchString, string? status, int? pageNumber, int? pageSize);
        Task<APIResponse<FieldDto>> GetFieldByIdAsync(string id);
        Task<APIResponse<FieldDto>> CreateFieldAsync(CreateFieldDto createFieldDto);
        Task<APIResponse<FieldDto>> UpdateFieldAsync(string id, UpdateFieldDto updateFieldDto);
        Task<APIResponse<bool>> DeleteFieldAsync(string id);
    }
}
