using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectUsers.Application.Users;
using ProjectUsers.Data.Context;
using ProjectUsers.Data.Repositories;
using ProjectUsers.Domain.Notifications;
using ProjectUsers.Domain.Repositories;

namespace ProjectUsers.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
    {
        // config banco
        services.AddScoped<AppDbContext>();

        var assembliesHandlers = AppDomain.CurrentDomain.Load("ProjectUsers.Application");

        services.AddMediatR(mediarConfig =>
        {
            mediarConfig.RegisterServicesFromAssemblies(assembliesHandlers);            
        });

        // repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Mapper
        services.AddAutoMapper(typeof(UserMapperConfig));

        // Notification
        services.AddScoped<INotificationContext, NotificationContext>();

        return services;
    }
}
