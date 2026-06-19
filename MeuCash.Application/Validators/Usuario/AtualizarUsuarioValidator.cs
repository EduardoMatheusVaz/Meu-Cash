using FluentValidation;
using MeuCash.Application.DTOs.Input_Models;

namespace MeuCash.Application.Validators.Usuario
{
    public class AtualizarUsuarioValidator : AbstractValidator<AtualizarUsuarioInputModel>
    {
        public AtualizarUsuarioValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0)
                    .WithMessage("Id tem que ser maior que 0")
                .NotEmpty()
                    .WithMessage("Id não pode estar vazio");

            RuleFor(p => p.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Nome não pode estar vazio")
                .MaximumLength(200)
                    .WithMessage("Tamanho não pode ser maior que 200 caracteres");

            RuleFor(p => p.Senha)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Senha não pode estar vazia")
                .MinimumLength(12)
                    .WithMessage("Tamanho não pode ser menor que 8")
                .MaximumLength(50)
                    .WithMessage("Tamanho não pode ser maior que 50 caracteres");

            RuleFor(p => p.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("E-mail não pode estar vazio")
                .EmailAddress()
                    .WithMessage("E-mail possui formato inválido")
                .MaximumLength(300)
                    .WithMessage("Tamanho não pode ser maior que 300 caracteres");

            RuleFor(p => p.UserName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Username não pode estar vazio")
                .MinimumLength(8)
                    .WithMessage("Tamanho não pode ser menor que 8")
                .MaximumLength(80)
                    .WithMessage("Tamanho não pode ser maior que 80 caracteres");

            RuleFor(p => p.NumeroCelular)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Número de celular não pode estar vazio")
                .Matches(@"^\(?\d{2}\)?\s?9\d{4}-?\d{4}$")
                    .WithMessage("Número inválido")
                .MaximumLength(24)
                    .WithMessage("Tamanho não pode ser maior que 24");
        }
    }
}
