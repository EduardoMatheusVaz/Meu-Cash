using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Entrada
{
    public class AtualizarEntradaValidator : AbstractValidator<AtualizarEntradaInputModel>
    {
        public AtualizarEntradaValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                    .WithMessage("Id não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("Id deve ser maior que 0");

            RuleFor(p => p.Valor)
                .NotEmpty()
                    .WithMessage("Valor não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("Valor deve ser maior que 0");
            
            RuleFor(p => p.Descricao)
                .MaximumLength(150)
                    .WithMessage("Tamanho não pode ser maior que 150 caracteres");
        }
    }
}
