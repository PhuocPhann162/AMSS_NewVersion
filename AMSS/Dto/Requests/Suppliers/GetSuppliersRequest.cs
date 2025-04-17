using AMSS.Enums;

namespace AMSS.Dto.Requests.Suppliers
{
    public class GetSuppliersRequest : PaginationRequest
    {
        public IEnumerable<string> CountryCodes { get; set; }
        public Role SupplierRole { get; set; }
    }
}
