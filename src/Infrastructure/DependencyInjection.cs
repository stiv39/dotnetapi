using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
