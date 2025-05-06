using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VM.Presistence.DatabaseContext;

namespace VM.Presistence
{
    public static class VmsPresistenceServiceRegistration
    {
        public static IServiceCollection AddPresistenceService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<VehicleMangementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("VmsDbConnection"));
            });
            return services;
        }
    }
}
