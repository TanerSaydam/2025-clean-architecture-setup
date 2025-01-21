using CleanArhictecture_2025.Application.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArhictecture_2025.Application;
public static class ApplicationRegistrar
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly);
            conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ApplicationRegistrar).Assembly);

        return services;
    }
}
