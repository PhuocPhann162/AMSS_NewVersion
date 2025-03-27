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
            Name = request.Name;
            Description = request.Description;
            SpecialTag = request.SpecialTag;
            Category = request.Category;
            Price = request.Price;
            ExpirationDate = request.ExpirationDate;
            Status = request.Status != default ? request.Status : CommodityStatus.Active;
            CropId = request.CropId;
            SupplierId = request.SupplierId;
        }
    }
}
