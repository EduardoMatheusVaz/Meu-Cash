using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Conta
{
    public class AtualizarContaValidator : AbstractValidator<AtualizarContaInputModel>
    {
        public AtualizarContaValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                    .WithMessage("Id não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("Id tem que ser maior do que 0");

            RuleFor(p => p.Saldo)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Saldo não pode ser menor do que 0");
        }
    }
}
