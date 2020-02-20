using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.SqlServer;
using Services.Implementations;
using Services.Interfaces;
using UnitOfWork.Interfaces;
using UnitOfWork.SqlServer;

namespace Api.Config
{
    public static class DependencesContainer
    {
        public static void AddMyDependencies(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWorkSqlServer>();
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // Services
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
