using AmediaTestCrud.Application.Intefaces.Services;
using AmediaTestCrud.Application.Services;
using AmediaTestCrud.Web.Services;

namespace AmediaTestCrud.Web.Configurations.DI;

public static class DefaultDI
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ICurrentUserContextService, CurrentUserContextService>();

        return services;
    }
}
