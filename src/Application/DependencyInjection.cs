using Application.Mapping;
using Application.Services;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IPostRepositoryService, PostRepositoryService>();
            services.AddScoped<ITodoRepositoryService, TodoRepositoryService>();

            return services;
        }
    }
}
