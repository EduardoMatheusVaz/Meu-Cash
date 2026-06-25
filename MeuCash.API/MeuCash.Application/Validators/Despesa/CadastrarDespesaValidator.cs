using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Despesa
{
    public class CadastrarDespesaValidator : AbstractValidator<DespesaInputModel>
    {
        public CadastrarDespesaValidator()
        {
            RuleFor(p => p.IdConta)
                .NotEmpty()
                    .WithMessage("IdConta não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("IdConta tem que ser maior do que 0");

            RuleFor(p => p.IdCategoria)
                .NotEmpty()
                    .WithMessage("IdCategoria não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("IdCategoria tem que ser maior do que 0");

            RuleFor(p => p.Valor)
                .NotEmpty()
                    .WithMessage("Valor não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("Valor deve ser maior que 0");

            RuleFor(p => p.Descricao)
                .NotEmpty()
                    .WithMessage("Descrição não pode estar vazia")
                .MaximumLength(150)
                    .WithMessage("Tamanho não pode ser maior que 150 caracteres");
        }
    }
}
