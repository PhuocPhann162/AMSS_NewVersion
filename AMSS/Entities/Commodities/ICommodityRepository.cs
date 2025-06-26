using AMSS.Models.Commodities;
using AMSS.Repositories.IRepository;

namespace AMSS.Entities.Commodities
{
    public interface ICommodityRepository : IRepository<Commodity>
    {
        Task<Commodity> GetCommodityOriginAsync(Guid commodityId);
    }
}
