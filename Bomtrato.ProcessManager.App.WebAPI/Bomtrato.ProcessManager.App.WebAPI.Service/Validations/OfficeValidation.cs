using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using FluentValidation;

namespace Bomtrato.ProcessManager.App.WebAPI.Service.Validations
{
    public class OfficeValidation : AbstractValidator<OfficeDomain>
    {
        public OfficeValidation()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome do escritório é um campo obrigatório")
            .MaximumLength(50).WithMessage("O campo do escritório deve ter no máximo 50 caracteres. (Apenas letras)");
            
        }
    }
}