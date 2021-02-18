using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services.Validations;
using Bomtrato.ProcessManager.App.WebAPI.Service.Validations;

namespace Bomtrato.ProcessManager.App.WebAPI.Service.Services.Validations
{
    public class ProcessValidationService : ValidationService<ProcessDomain>, IProcessValidationService
    {
        public ProcessValidationService(ProcessValidation processValidation)
        : base(processValidation)
        {
            
        }
    }
}