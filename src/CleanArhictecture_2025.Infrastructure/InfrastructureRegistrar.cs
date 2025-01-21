using CleanArhictecture_2025.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace CleanArhictecture_2025.Infrastructure;
public static class InfrastructureRegistrar
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            string connectionString = configuration.GetConnectionString("SqlServer")!;
            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        services.Scan(opt => opt
        .FromAssemblies(typeof(InfrastructureRegistrar).Assembly)
        .AddClasses(publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        );

        return services;
    }
}
