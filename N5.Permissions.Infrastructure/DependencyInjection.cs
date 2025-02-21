using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5.Permissions.Infrastructure.Persistence;
using N5.Permissions.Application.Permissions.Persistence;
using N5.Permissions.Application.Persistence.Repositories;
using N5.Permissions.Infrastructure.Persistence.Repositories;

namespace N5.Permissions.Infrastructure
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddPersistence(configuration);
            services.AddAuth();
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddAuth(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<PermissionDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:PermissionsContext"]));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {            
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
            return services;
        }
    }
}
