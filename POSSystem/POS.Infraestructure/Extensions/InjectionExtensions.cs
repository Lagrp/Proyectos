using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Infraestructure.Persistences.Repositories;

namespace POS.Infraestructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DbContext).Assembly.FullName;
            services.AddDbContext<DbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DbPosConnection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}