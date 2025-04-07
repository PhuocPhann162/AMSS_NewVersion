namespace AMSS.Infrastructures.Interfaces
{
    public interface IRedisCacheService
    {
        Task<T> GetData<T>(string key);
        Task<bool> SetData<T>(string key, T value, TimeSpan? expirationTime);
        Task<bool> RemoveData(string key);
    }
}
