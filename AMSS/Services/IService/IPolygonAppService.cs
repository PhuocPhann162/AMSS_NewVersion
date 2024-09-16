using AMSS.Models;
using AMSS.Models.Dto.Polygon;
using Microsoft.AspNetCore.Mvc;

namespace AMSS.Services.IService
{
    public interface IPolygonAppService 
    {
        Task<APIResponse<IEnumerable<PolygonDto>>> GetAllPolygonsAsync();
        Task<APIResponse<PolygonDto>> CreatePolygonAsync(CreatePolygonDto createPolygonDto);
        Task<APIResponse<PolygonDto>> UpdatePolygonAsync(UpdatePolygonDto updatePolygonDto);
    }
}
