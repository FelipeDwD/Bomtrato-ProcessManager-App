using Microsoft.Extensions.DependencyInjection;

namespace Bomtrato.ProcessManager.App.WebAPI.Application.Config
{
    public static class CorsConfig
    {
        public static IServiceCollection ConfigCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                builder => 
                builder
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            });

            return services;
        }
    }
}