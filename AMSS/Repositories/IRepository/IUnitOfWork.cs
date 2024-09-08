using AMSS.Repository.IRepository;

namespace AMSS.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        ICropRepository CropRepository { get; }
        ICropTypeRepository CropTypeRepository { get; }
        IFarmRepository FarmRepository { get; }
        IFieldRepository FieldRepository { get; }
        IFieldCropRepository FieldCropRepository { get; }
        ILocationRepository LocationRepository { get; }
        IPolygonAppRepository PolygonAppRepository { get; }
        IPositionRepository PositionRepository { get; }
        IUserRepository UserRepository { get; }

        void SaveAsync();
    }
}
