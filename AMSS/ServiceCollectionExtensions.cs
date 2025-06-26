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
using Microsoft.AspNetCore.Mvc;
using AMSS.Models;
using AMSS.Services.IService.IGeneratePdf;
using AMSS.Services.GeneratePdf;
using DinkToPdf.Contracts;
using DinkToPdf;
using AMSS.Services.IService.IChatService;
using AMSS.Services.ChatService;

namespace AMSS
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddExternalReferences(configuration);
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
            services.AddScoped<IRedisCacheService, RedisCacheService>();
            services.AddScoped<IMetatDataService, MetaDataService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IHarvestExportService, HarvestExportService>();
            services.AddScoped<IGeneratePdfService, GeneratePdfService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IReportService, ReportService>();
        }

        private static void AddExternalReferences(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangFireServices(configuration);
            services.AddSmtpService(configuration);
            services.AddRedisCacheService(configuration);
            services.AddBackgroundService();
            services.AddConfigurationSettings(configuration);
            services.AddErrorValidateCustomService();
            services.AddPdfService();
            services.AddSignalRService();
        }

        private static void AddSmtpService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpConfiguration>(configuration.GetSection("SmtpSettings"));
            services.AddTransient<ISmtpService, SmtpService>();
        }

        private static void AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<StripePaymentConfiguration>(configuration.GetSection("StripeSettings"));
            services.Configure<SupplierConfiguration>(configuration.GetSection("SupplierSettings"));
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings")); 
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

        private static void AddPdfService(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddTransient<IPdfConverter, PdfConverter>();
        }

        private static void AddErrorValidateCustomService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressMapClientErrors = true;
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new NovarisValidationFailedResult(context.ModelState);

                    return result;
                };
            });
        }

        private static void AddSignalRService(this IServiceCollection services)
        {
            services.AddSignalR();
        }
    }
}
