using HaileDinner.Application.Common.Interfaces.Authentication;
using HaileDinner.Application.Common.Interfaces.Persistance;
using HaileDinner.Application.Common.Services;
using HaileDinner.infrastructure.Authentication;
using HaileDinner.infrastructure.Persistance;
using HaileDinner.infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HaileDinner.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator> ();
            services.AddSingleton<IDateTimeProvider,DateTimeProvider> ();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
