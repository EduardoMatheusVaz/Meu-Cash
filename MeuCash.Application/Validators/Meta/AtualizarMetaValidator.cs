using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Meta
{
    public class AtualizarMetaValidator : AbstractValidator<AtualizarMetaInputModel>
    {
        public AtualizarMetaValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                    .WithMessage("Id não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("Id tem que ser maior que 0");

            RuleFor(p => p.Nome)
                .MaximumLength(100)
                    .WithMessage("Tamanho não pode ser maior que 100 caracteres");

            RuleFor(d => d.Descricao)
                .MaximumLength(500)
                    .WithMessage("Tamanho não pode ser maior que 500 caracteres");

            RuleFor(p => p.Valor)
                .NotEmpty()
                    .WithMessage("Valor não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("Valor deve ser maior que 0");

            RuleFor(p => p.DataLimite)
                .LessThanOrEqualTo(DateTime.Today)
                    .WithMessage("A data não pode ser maior que a data atual");
        }
    }
}
