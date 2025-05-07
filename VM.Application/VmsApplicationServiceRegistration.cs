using Microsoft.Extensions.DependencyInjection;

namespace VM.Application
{
    public static class VmsApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            return services;
        }
    }
}
