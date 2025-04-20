using AMSS.Aggregates;
using AMSS.Dto.Auth;
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
            Address = request.StreetAddress;
            Lat = request.Lat;
            Lng = request.Lng;
            CountryCode = request.Country;
            ApplicationUserId = userId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Update(UpdateCouponRequest request)
        {

        }
    }
}
