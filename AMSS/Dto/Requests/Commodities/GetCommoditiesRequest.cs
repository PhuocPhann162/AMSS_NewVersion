using AMSS.Enums;

namespace AMSS.Dto.Requests.Commodities
{
    public class GetCommoditiesRequest : PaginationRequest
    {
        public IEnumerable<CommodityCategory> Categories { get; set; }
        public IEnumerable<CommodityStatus> Statuses { get; set; }
    }
}
