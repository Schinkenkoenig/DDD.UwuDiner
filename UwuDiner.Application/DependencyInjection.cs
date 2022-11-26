using Microsoft.Extensions.DependencyInjection;
using UwuDiner.Application.Services.Authentication;

namespace UwuDiner.Application;

public static class DependencyInjection
{

  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IAuthenticationService, AuthenticationService>();
    return services;
  }
}
