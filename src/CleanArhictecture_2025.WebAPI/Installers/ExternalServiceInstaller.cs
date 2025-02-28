using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.RateLimiting;

namespace CleanArhictecture_2025.WebAPI.Installers;

public static class ExternalServiceInstaller
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddOpenApi();
        services
            .AddControllers()
            .AddOData(opt =>
            opt.Select()
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .SetMaxTop(null)
        );
        services.AddRateLimiter(x =>
            x.AddFixedWindowLimiter("fixed", cfg =>
            {
                cfg.QueueLimit = 100;
                cfg.Window = TimeSpan.FromSeconds(1);
                cfg.PermitLimit = 100;
                cfg.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            })
        );
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();
        services.AddAuthorization();
        services.AddResponseCompression(opt =>
        {
            opt.EnableForHttps = true;
        });    
        return services;
    }
}