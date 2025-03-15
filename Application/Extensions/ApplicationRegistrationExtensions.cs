using Microsoft.Extensions.DependencyInjection;

namespace SportNest.Application.Extensions;

public static class ApplicationRegistrationExtensions
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
    {
        return services.AddMediatR(
            config => config.RegisterServicesFromAssemblies(
                typeof(ApplicationRegistrationExtensions).Assembly
            ));
    }

}