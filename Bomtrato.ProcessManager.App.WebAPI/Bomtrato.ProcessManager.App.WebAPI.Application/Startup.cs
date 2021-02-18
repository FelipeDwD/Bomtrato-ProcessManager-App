using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bomtrato.ProcessManager.App.WebAPI.Application.Config;
using Bomtrato.ProcessManager.App.WebAPI.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Bomtrato.ProcessManager.App.WebAPI.Application
{
    public class Startup
    {
        public IConfiguration _configuration { get; }        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();           

            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(_configuration.GetConnectionString("ApplicationDbContext")));

            services.GetInjections();
            services.ConfigCors();

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new OpenApiInfo {Title = "Bomtrato - ProcessManagerAPI", Version = "v1"});
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("Development");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "V1");
            });

        }
    }
    
}
