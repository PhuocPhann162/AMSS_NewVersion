using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Suppliers
{
    public class GetSuppliersResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContactName { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public string ProvinceName { get; set; }

        public string ProvinceCode { get; set; }

        public string PhoneCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
