using System.Text.Json.Serialization;

namespace AMSS.Dto.Requests.Suppliers
{
    public class UpdateSupplierRequest
    {
        public string Name { get; set; }

        public string ContactName { get; set; }

        public string PhoneCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
