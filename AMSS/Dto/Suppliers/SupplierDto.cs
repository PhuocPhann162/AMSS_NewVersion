using AMSS.Enums;

namespace AMSS.Dto.Suppliers
{
    public class SupplierDto
    {
        public Guid Id { get; set; }  

        public string Name { get; set; }

        public string ContactName { get; set; }

        public string PhoneCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string ProvinceCode { get; set; }

        public string ProvinceName { get; set; }
    }
}
