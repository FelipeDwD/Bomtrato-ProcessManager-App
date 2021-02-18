using System.Collections.Generic;
using System.Linq;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Interfaces.Services.Validations;
using FluentValidation;
using FluentValidation.Results;

namespace Bomtrato.ProcessManager.App.WebAPI.Service.Services.Validations
{
   public abstract class ValidationService<Te> : IValidationService<Te> where Te : Entity
    {
        private AbstractValidator<Te> _typeValidation;
        public ValidationService(AbstractValidator<Te> typeValidation)
        {
            _typeValidation = typeValidation;
        }
        public List<string> Validate(Te typeEntity)
        {
            var validator = _typeValidation.Validate(typeEntity);

            if(validator.IsValid)
                return null;

            var messages = GetMessages(validator);
            return messages;
        }

        private List<string> GetMessages(ValidationResult validationResult)
        {
            var errors = (from error in validationResult.Errors
                            select error.ErrorMessage).ToList();

            return errors;
        }
    }
}