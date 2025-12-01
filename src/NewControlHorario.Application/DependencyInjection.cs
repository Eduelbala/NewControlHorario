using Microsoft.Extensions.DependencyInjection;
using NewControlHorario.Application.Services;

namespace NewControlHorario.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITimeEntryService, TimeEntryService>();
        return services;
    }
}
