using MeuCash.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MeuCash.API.ExceptionHandler
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var details = new ProblemDetails();

            if (exception is CategoriaNaoEncontradaException      || 
                exception is ContaNaoEncontradaException          || 
                exception is EntradasNaoEncontradasContaException ||
                exception is DespesaNaoEncontradaException        ||
                exception is MetaNaoEncontradaException           ||
                exception is UsuarioNaoEncontradoException        ||
                exception is DespesaIdContaNaoEncontradaException ||
                exception is EntradasNaoEncontradasContaException ||
                exception is MetasNaoEncontradasContaException)
            {
                details.Title = "Consulta não pode ser realizada";
                details.Status = StatusCodes.Status404NotFound;
                details.Detail = exception.Message;
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }

            if (exception is CategoriaInativaException || exception is CategoriaAtivaException ||
                exception is ContaInativaException     || exception is ContaAtivaException     ||
                exception is EntradaInativadaException || exception is EntradaAtivaException   ||
                exception is DespesaInativaException   || exception is DespesaAtivaException   ||
                exception is MetaInativaException      || exception is MetaAtivaException      ||
                exception is UsuarioInativadoException || exception is UsuarioAtivoException)
            {
                details.Title = "Operação inválida";
                details.Status = StatusCodes.Status409Conflict;
                details.Detail = exception.Message;
                httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
            }

            //TODO: Eduardo Vaz: 18/06/2026: Fazer um tratamento padrão para erros inesperados

            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

            return true;
        }
    }
}
