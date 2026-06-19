using FluentValidation;
using FluentValidation.AspNetCore;
using MeuCash.Application.Validators.Usuario;
using Microsoft.Extensions.DependencyInjection;

namespace MeuCash.Application.Validators
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddValidation();

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CadastrarUsuarioValidator>();

            return services;
        }
    }
}
