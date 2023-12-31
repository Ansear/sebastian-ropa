using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Infratructure.UnitOfWork;

namespace api.Extensions;
public static class ApplicationServicesExtension
{      
    public static void ConfigureCors(this IServiceCollection services)=>
    services.AddCors(options => {
        options.AddPolicy(
            "CorsPolicy",
            builder =>
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
        );
    });

    public static void ConfigureRateLimit(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(options => {
            options.EnableEndpointRateLimiting = true;
            options.StackBlockedRequests= false;
            options.HttpStatusCode = 429;
            options.RealIpHeader = "X-Real-IP";
            options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule{
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 2
                }
            };
        });
    }

    public static void AddAplicationServices(this IServiceCollection services){
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}