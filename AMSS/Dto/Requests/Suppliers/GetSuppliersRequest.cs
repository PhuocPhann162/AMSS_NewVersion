using AMSS.Enums;

namespace AMSS.Dto.Requests.Suppliers
{
    public class GetSuppliersRequest : PaginationRequest
    {
        public Role SupplierRole { get; set; }
    }
}
