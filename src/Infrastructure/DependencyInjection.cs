using Domain.Interfaces;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

            
           
            services.AddScoped<IPostRepository, PostRepository>();
            // Scrutor
            services.Decorate<IPostRepository, CachedPostRepository>();

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.Decorate<ITodoRepository, CachedTodoRepository>();

            services.AddMemoryCache();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
