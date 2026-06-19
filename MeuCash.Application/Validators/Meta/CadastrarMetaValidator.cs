using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Meta
{
    public class CadastrarMetaValidator : AbstractValidator<MetaInputModel>
    {
        public CadastrarMetaValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                    .WithMessage("Nome não pode estar vazio")
                .MaximumLength(100)
                    .WithMessage("Tamanho não pode ser maior que 100 caracteres");

            RuleFor(d => d.Descricao)
                .MaximumLength(500)
                    .WithMessage("Tamanho não pode ser maior que 500 caracteres");

            RuleFor(p => p.IdUsuario)
                .NotEmpty()
                    .WithMessage("IdUsuario não pode estar vazio")
                .GreaterThan(0)
                    .WithMessage("IdUsuario deve ser maior que 0");

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

            RuleFor(p =>  p.DataLimite)
                .LessThanOrEqualTo(DateTime.Today)
                    .WithMessage("A data não pode ser maior que a data atual");
        }
    }
}
