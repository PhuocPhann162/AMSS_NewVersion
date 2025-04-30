using AMSS.Aggregates;
using AMSS.Dto.Auth;
using AMSS.Dto.Location;
using AMSS.Dto.Requests.Coupons;

namespace AMSS.Entities.Locations
{
    public partial class Location : IAggregateRoot
    {
        public Location()
        {

        }

        public Location(RegistrationRequestDto request, Guid userId)
        {
            Id = Guid.NewGuid();
            Address = request.StreetAddress;
            Lat = request.Lat;
            Lng = request.Lng;
            CountryCode = request.Country;
            ApplicationUserId = userId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Location(CreateLocationDto request) 
        {
            Id = Guid.NewGuid();
            Address = request.Address.Trim();
            Lat = request.Lat;
            Lng = request.Lng;
            CountryCode = request.CountryCode.ToUpper();
            City = request.City;
            State = request.State;
            District = request.District;
            Road = request.Road;
            PostCode = request.PostCode;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Update(UpdateCouponRequest request)
        {

        }
    }
}
