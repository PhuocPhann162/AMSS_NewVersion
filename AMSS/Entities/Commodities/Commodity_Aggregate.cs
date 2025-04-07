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
            Name = request.Name.Trim();
            Description = request.Description.Trim();
            SpecialTag = request.SpecialTag.Trim();
            Category = request.Category.Trim();
            Price = request.Price;
            ExpirationDate = request.ExpirationDate;
            Status = request.Status != default ? request.Status : CommodityStatus.Active;
            CropId = request.CropId;
            SupplierId = request.SupplierId;
        }

        public void Update(UpdateCommodityRequest request)
        {
            Name = request.Name.Trim();
            Description = request.Description.Trim();
            SpecialTag = request.SpecialTag.Trim();
            Category = request.Category.Trim();
            Price = request.Price;
            ExpirationDate = request.ExpirationDate;
            Status = request.Status;
            CropId = request.CropId;
            SupplierId = request.SupplierId;
        }
    }
}
