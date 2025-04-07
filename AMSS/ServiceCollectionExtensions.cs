using Hangfire.Server;
using Hangfire;
using Hangfire.SqlServer;
using AMSS.Repositories.IRepository;
using AMSS.Repositories;
using AMSS.Services.IService;
using AMSS.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using AMSS.Infrastructures.Interfaces;
using AMSS.Infrastructures.Configurations;
using AMSS.Infrastructures.Services;
using AMSS.Services.IService.BackgroundJob;
using AMSS.Services.BackgroundJob;
using AMSS.Constants;

namespace AMSS
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddHangFireServices(configuration);
            services.AddWebServices();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description =
                         "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                         "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                         "Example: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
            services.AddSmtpService(configuration);
            services.AddBackgroundService();
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
            services.AddHangfireServer(options =>
            {
                options.WorkerCount = 1;
                options.Queues = [QueueName.SendEmailJob];
            });
            services.AddHangfireServer();
        }

        private static void AddWebServices (this IServiceCollection services)
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
            services.AddScoped<ICommodityService, CommodityService>();
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISmtpService, SmtpService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ISerializeService, SerializeService>();
        }

        private static void AddSmtpService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpConfiguration>(configuration.GetSection("SmtpSettings"));
            services.AddTransient<ISmtpService, SmtpService>();
        }

        private static void AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<StripePaymentConfiguration>(configuration.GetSection("StripeSettings"));
        }

        private static void AddBackgroundService(this IServiceCollection services)
        {
            services.AddScoped<ISendEmailJob, SendEmailJob>();
        }

        private static void AddRedisCacheService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = configuration.GetConnectionString("Redis");
                option.InstanceName = "Noavaris_";
            });
        }
    }
}
