using Bomtrato.ProcessManager.App.WebAPI.Data.Repository;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Repositories;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services.Validations;
using Bomtrato.ProcessManager.App.WebAPI.Service.Services;
using Bomtrato.ProcessManager.App.WebAPI.Service.Services.Validations;
using Bomtrato.ProcessManager.App.WebAPI.Service.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace Bomtrato.ProcessManager.App.WebAPI.Application.Config
{
    public static class InjectionMap
    {
        public static IServiceCollection GetInjections(this IServiceCollection services)
        {
            services.AddScoped<IApproverService, ApproverService>();
            services.AddScoped<IApproverRepository, ApproverRepository>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IProcessService, ProcessService>();
            services.AddScoped<IProcessRepository, ProcessRepository>();
            services.AddScoped<IProcessValidationService, ProcessValidationService>();            
            services.AddScoped<IOfficeValidationService, OfficeValidationService>();
            services.AddScoped<ProcessValidation>();   
            services.AddScoped<OfficeValidation>();         
            return services;
        }   
    }
}