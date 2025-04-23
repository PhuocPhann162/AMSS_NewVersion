namespace AMSS.Dto.Requests.Users
{
    public class GetCustomersRequest : PaginationRequest
    {
        public IEnumerable<string> CountryCodes { get; set; }
    }
}
