using Hangfire.Server;
using Hangfire;
using Hangfire.SqlServer;
using AMSS.Repositories.IRepository;
using AMSS.Repositories;
using AMSS.Services.IService;
using AMSS.Services;

namespace AMSS
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddHangFireServices(configuration);
            services.AddWebServices(configuration);
        }

        private static void AddHangFireServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(x => x
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("AMSSConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));
            services.AddSingleton<IBackgroundProcessingServer>(_ => new BackgroundJobServer());
            services.AddHangfireServer();
        }

        private static void AddWebServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICropService, CropService>();
            services.AddScoped<ICropTypeService, CropTypeService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<IFarmService, FarmService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IPolygonAppService, PolygonAppService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISocialMetricService, SocialMetricService>();

        }
    }
}
