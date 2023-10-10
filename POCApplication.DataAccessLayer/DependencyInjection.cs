using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POCApplication.DataAccessLayer.DataContext;
using POCApplication.DataAccessLayer.Repositories;
using POCApplication.DataAccessLayer.Repositories.Interfaces;

namespace POCApplication.DataAccessLayer
{
    public static class DependencyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
