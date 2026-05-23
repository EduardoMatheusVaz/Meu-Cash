using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IContaService
    {
        Task<ContaDetalhesIdViewModel> ConsultarContaPeloId(int id);
        Task<List<ContaDetalhesIdViewModel>> ConsultarContas();
        Task CriarConta(ContaInputModel contaInputModel);
    }
}
