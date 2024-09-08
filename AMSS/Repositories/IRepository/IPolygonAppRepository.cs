using AMSS.Models.Polygon;

namespace AMSS.Repositories.IRepository
{
    public interface IPolygonAppRepository : IRepository<PolygonApp>
    {
        Task<PolygonApp> Update(PolygonApp polygonApp);
    }
}
