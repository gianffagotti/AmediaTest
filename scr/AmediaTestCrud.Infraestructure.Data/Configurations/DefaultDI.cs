using AmediaTestCrud.Application.Intefaces.Infraestructure.Data;
using AmediaTestCrud.Infraestructure.Data.Contexts;
using AmediaTestCrud.Infraestructure.Data.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmediaTestCrud.Infraestructure.Data.Configurations;

public static class DefaultDI
{
    public static IServiceCollection AddContextDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TestCrudContext>(options => options.UseSqlServer(configuration.GetConnectionString("TestCrud")));

        services.AddScoped<IUserData, UserData>();
        services.AddScoped<IRoleData, RoleData>();

        return services;
    }
}
