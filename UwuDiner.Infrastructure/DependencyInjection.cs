using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UwuDiner.Application.Common.Interfaces.Persistence;
using UwuDiner.Application.Interfaces.Authentication;
using UwuDiner.Application.Interfaces.Services;
using UwuDiner.Infrastructure.Authentication;
using UwuDiner.Infrastructure.Persistence;
using UwuDiner.Infrastructure.Services;

namespace UwuDiner.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    ConfigurationManager configuration)
  {
    services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

    services.AddScoped<IUserRepository, UserRepository>();
    return services;
  }
}
