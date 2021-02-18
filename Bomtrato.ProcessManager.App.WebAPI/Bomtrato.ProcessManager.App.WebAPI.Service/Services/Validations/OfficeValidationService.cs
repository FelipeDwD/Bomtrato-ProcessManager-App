using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services.Validations;
using Bomtrato.ProcessManager.App.WebAPI.Service.Validations;

namespace Bomtrato.ProcessManager.App.WebAPI.Service.Services.Validations
{
    public class OfficeValidationService : ValidationService<OfficeDomain>, IOfficeValidationService
    {
        public OfficeValidationService(OfficeValidation officeValidation)
        : base(officeValidation)
        {
            
        }
    }
}