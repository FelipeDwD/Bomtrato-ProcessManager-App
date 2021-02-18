using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;
using FluentValidation;

namespace Bomtrato.ProcessManager.App.WebAPI.Service.Validations
{
    public class ProcessValidation : AbstractValidator<ProcessDomain>
    {
        public ProcessValidation()
        {
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("O Número do processo é um campo obrigatório")
                .Length(min: 12, max: 12).WithMessage("O campo Número do processo é composto por 12 caracteres");

            RuleFor(x => x.CasueValue)
                .NotEmpty().WithMessage("O Valor é um campo obrigatório")
                .GreaterThan((decimal)29999.99).WithMessage("O valor da causa deve ser superior a R$ 30.000,00 reais");

            RuleFor(x => x.IdOffice)
                .NotEmpty().WithMessage("Favor selecionar um escritório");
                

            RuleFor(x => x.ComplainingName)
                .NotEmpty().WithMessage("O Nome do reclamante é obrigatório")
                .MaximumLength(100).WithMessage("O nome do reclamante tem como limite 100 caracteres (apenas letras).");

        }
    }
}