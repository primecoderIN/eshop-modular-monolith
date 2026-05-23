
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Ordering;

public static class OrderModule
{
      public static IServiceCollection AddOrderingModule(this IServiceCollection services, IConfiguration configuration )
    {
        return services;
    }
}
