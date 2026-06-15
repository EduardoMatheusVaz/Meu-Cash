using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IContaService
    {
        Task<ContaDetalhesIdViewModel> ConsultarContaPeloId(int id);
        Task<List<ContaDetalhesIdViewModel>> ConsultarContas();
        Task<List<ContaDetalhesIdViewModel>> ConsultarContasInativadas();
        Task CriarConta(ContaInputModel contaInputModel);
        Task Inativar(int id, string motivoExclusao);
        Task Ativar(int id);
        Task Atualizar(AtualizarContaInputModel atualizarContaInputModel);
        Task<Conta> ValidaContaExiste(int id);
    }
}
