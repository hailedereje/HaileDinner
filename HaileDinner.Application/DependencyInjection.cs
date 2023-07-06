
using HaileDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace HaileDinner.Application;

public static class DependecyInJection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService,AuthenticationService>();
        return services;
    }
}