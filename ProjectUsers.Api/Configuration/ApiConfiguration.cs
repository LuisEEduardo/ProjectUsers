using Microsoft.EntityFrameworkCore;
using ProjectUsers.Data.Context;
using ProjectUsers.Infra.IoC;

namespace ProjectUsers.Api.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            services.AddDependencyInjectionConfig(configuration);

            return services;
        }
    }
}
