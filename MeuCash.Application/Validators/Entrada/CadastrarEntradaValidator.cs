using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Entrada
{
    public class CadastrarEntradaValidator : AbstractValidator<EntradaInputModel>
    {
        public CadastrarEntradaValidator()
        {
            RuleFor(p => p.IdConta)
                .NotEmpty()
                    .WithMessage("IdConta não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("IdConta deve ser maior que 0");

            RuleFor(p => p.Valor)
                .NotEmpty()
                    .WithMessage("Valor não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("Valor deve ser maior que 0");

            RuleFor(p => p.Data)
                .NotEmpty()
                    .WithMessage("Data não pode estar vazia")
                .LessThanOrEqualTo(DateTime.Today)
                    .WithMessage("A data não pode ser maior que a data atual");

            RuleFor(p => p.Descricao)
                .MaximumLength(150)
                    .WithMessage("Tamanho não pode ser maior que 150 caracteres");
        }
    }
}
