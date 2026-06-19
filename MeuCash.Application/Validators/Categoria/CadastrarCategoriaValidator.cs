using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Categoria
{
    public class CadastrarCategoriaValidator : AbstractValidator<CategoriaInputModel>
    {
        public CadastrarCategoriaValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                    .WithMessage("Nome não pode estar vazio")
                .MaximumLength(50)
                    .WithMessage("Tamanho não pode ser maior que 50 caracteres");
        }
    }
}
