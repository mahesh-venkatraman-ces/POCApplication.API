using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POCApplication.BusinessLayer.Services;
using POCApplication.BusinessLayer.Services.Interfaces;
using POCApplication.BusinessLayer.Utilities.AutomapperProfiles;

namespace POCApplication.BusinessLayer;

public static class DependencyInjection
{
    public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddAutoMapper(typeof(AutoMapperProfiles));
        services.AddScoped<IUserService, UserService>();
        DataAccessLayer.DependencyInjection.RegisterDALDependencies(services, Configuration);
    }
}