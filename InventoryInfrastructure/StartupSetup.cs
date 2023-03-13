using InventoryCore.Interface;
using InventoryInfrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InventoryInfrastructure
{
    public static class StartupSetup
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBConnectionString"), builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            services.AddScoped<AppDbContextInitialiser>();

            services.AddScoped<IRepository,EfRepository>();
        }

    }
}
