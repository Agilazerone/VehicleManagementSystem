using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VM.Domain.Contracts.Presistence;
using VM.Presistence.DatabaseContext;
using VM.Presistence.Repository;

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
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;

        }
    }
}
