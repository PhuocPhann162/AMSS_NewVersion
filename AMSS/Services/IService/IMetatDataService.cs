using AMSS.Dto.Responses.Countries;
using AMSS.Entities;

namespace AMSS.Services.IService
{
    public interface IMetatDataService
    {
        Task<APIResponse<IEnumerable<CountrySelectionResponse<string>>>> GetCountriesSelectionAsync();
        Task<APIResponse<Dictionary<string, string>>> GetCountriesAsync();
    }
}
