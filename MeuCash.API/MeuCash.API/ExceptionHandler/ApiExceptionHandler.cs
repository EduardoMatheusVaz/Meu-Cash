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

            if (exception is RegistroIdEncontradoException)
            {
                details.Title = "Consulta não pode ser realizada";
                details.Status = StatusCodes.Status404NotFound;
            }
            else if (exception is EntidadeAtivaException || exception is EntidadeInativaException)
            {
                details.Title = "Operação inválida";
                details.Status = StatusCodes.Status409Conflict;
            }
            else if (exception is EntidadeJaExisteException)
            {
                details.Title = "Registro duplicado";
                details.Status = StatusCodes.Status409Conflict;
            }
            else if (exception is OperacaoNaoPermitidaException)
            {
                details.Title = "Operação não pode ser realizada";
                details.Status = StatusCodes.Status403Forbidden;
            }
            else
            {
                details.Title = "!Erro do servidor!";
                details.Status = StatusCodes.Status500InternalServerError;
            }

            details.Detail = exception.Message;
            httpContext.Response.StatusCode = details.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

            return true;
        }
    }
}
