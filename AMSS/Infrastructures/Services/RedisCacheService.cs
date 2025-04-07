using AMSS.Infrastructures.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace AMSS.Infrastructures.Services
{
    public class RedisCacheService
        (ILogger _logger, IDistributedCache _redisCacheService, 
        ISerializeService _serializeService) : IRedisCacheService
    {
        public async Task<T> GetData<T>(string key)
        {
            _logger.LogInformation("BEGIN: GetData<{DataType}>(key: {KeyName})", typeof(T).Name, key);

            string value = await _redisCacheService.GetStringAsync(key);
            if (!string.IsNullOrEmpty(value))
            {
                return _serializeService.Deserialize<T>(value);
            }

            _logger.LogInformation("END: GetData<{DataType}>", typeof(T).Name);

            return default;
        }

        public async Task<bool> SetData<T>(string key, T value, TimeSpan? expirationTime)
        {
            _logger.LogInformation("BEGIN: GetData<{DataType}>(key: {KeyName}, value: {Value})", typeof(T).Name, key, value);

            var options = new DistributedCacheEntryOptions();

            if (expirationTime.HasValue)
            {
                options.SetAbsoluteExpiration(expirationTime.Value);
            }

            await _redisCacheService.SetStringAsync(key, _serializeService.Serialize(value), options);

            _logger.LogInformation("END: GetData<{DataType}>", typeof(T).Name);

            return true;
        }

        public async Task<bool> RemoveData(string key)
        {
            try
            {
                _logger.LogInformation("BEGIN: RemoveData(key: {KeyName})", key);

                string value = await _redisCacheService.GetStringAsync(key);
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Value is null or empty!");
                }

                await _redisCacheService.RemoveAsync(key);

                _logger.LogInformation("END: RemoveData");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RemoveData: {Message}", ex.Message);
                return false;
            }
        }
    }
}
