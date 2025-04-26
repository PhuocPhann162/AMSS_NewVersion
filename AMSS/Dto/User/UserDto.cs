using AMSS.Enums;

namespace AMSS.Dto.User
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public string? ProvinceName { get; set; }

        public string? ProvinceCode { get; set; }

        public string PhoneCode { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAddress { get; set; }

        public bool IsActive { get; set; }

        public string RefreshToken { get; set; }

        public string Avatar { get; set; }

        public Role Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid? SupplierId { get; set; }
    }
}
