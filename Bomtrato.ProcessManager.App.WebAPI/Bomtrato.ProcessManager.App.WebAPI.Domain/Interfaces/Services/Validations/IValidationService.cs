using System.Collections.Generic;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services.Validations
{
    public interface IValidationService<Te> where Te : Entity
    {
         List<string> Validate(Te typeEntity);
    }
}