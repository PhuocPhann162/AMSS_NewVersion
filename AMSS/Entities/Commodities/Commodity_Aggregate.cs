using AMSS.Aggregates;
using AMSS.Dto.Requests.Commodities;
using AMSS.Enums;

namespace AMSS.Models.Commodities
{
    public partial class Commodity : IAggregateRoot
    {
        public Commodity()
        {
            
        }

        public Commodity(CreateCommodityRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name.Trim();
            Description = request.Description.Trim();
            Category = request.Category;
            Price = request.Price;
            ExpirationDate = request.ExpirationDate;
            Status = request.Status;
            CropId = request.CropId;
            SupplierId = request.SupplierId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Update(UpdateCommodityRequest request)
        {
            Name = request.Name.Trim();
            Description = request.Description.Trim();
            Category = request.Category;
            Price = request.Price;
            ExpirationDate = request.ExpirationDate;
            Status = request.Status;
            CropId = request.CropId;
            SupplierId = request.SupplierId;
            UpdatedAt = DateTime.Now;
        }
    }
}
