using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Categoria
{
    public class AtualizarCategoriaValidator : AbstractValidator<AtualizarCategoriaInputModel>
    {
        public AtualizarCategoriaValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                    .WithMessage("Id não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("Id tem que ser maior do que zero");

            RuleFor(p => p.Nome)
                .NotEmpty()
                    .WithMessage("Nome não pode estar vazio")
                .MaximumLength(50)
                    .WithMessage("Tamanho não pode ser maior que 50 caracteres");
        }
    }
}
