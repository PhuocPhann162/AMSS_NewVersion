using AMSS.Dto.Responses.Countries;
using AMSS.Entities;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;

namespace AMSS.Services
{
    public class MetaDataService : BaseService, IMetatDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MetaDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork  = unitOfWork;
        }

        public async Task<APIResponse<Dictionary<string, string>>> GetCountriesAsync()
        {
            var countryContinents = await _unitOfWork.CountryContinentRepository.GetRESAsync();
            var countryDictionary = new Dictionary<string, string>();

            foreach (var countryContinent in countryContinents)
            {
                if (!countryDictionary.ContainsKey(countryContinent.CountryCode))
                {
                    countryDictionary.Add(countryContinent.CountryCode, countryContinent.CountryName);
                }
            }

            return BuildSuccessResponseMessage(countryDictionary);
        }

        public async Task<APIResponse<IEnumerable<CountrySelectionResponse<string>>>> GetCountriesSelectionAsync()
        {
            var countryContinents = await _unitOfWork.CountryContinentRepository.GetRESAsync();
            var response = new List<CountrySelectionResponse<string>>();

            foreach (var countryContinent in countryContinents)
            {
                response.Add(new CountrySelectionResponse<string>(
                    countryContinent.CountryCode,
                    countryContinent.CountryName,
                    countryContinent.PhoneCode));
            }

            return BuildSuccessResponseMessage(response.AsEnumerable());
        }
    }
}
