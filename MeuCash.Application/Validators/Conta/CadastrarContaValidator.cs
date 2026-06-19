using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Conta
{
    public class CadastrarContaValidator : AbstractValidator<ContaInputModel>
    {
        public CadastrarContaValidator()
        {
            RuleFor(p => p.IdUsuario)
                .NotEmpty()
                    .WithMessage("IdUsuario não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("IdUsuario tem que ser maior do que 0");

            RuleFor(p => p.SaldoAtual)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Saldo inicial não pode ser menor do que 0");
        }
    }
}
