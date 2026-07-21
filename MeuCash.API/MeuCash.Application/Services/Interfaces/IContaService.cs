using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IContaService
    {
        Task<Result<ContaDetalhesIdViewModel>> ConsultarContaPeloId(int id);
        Task<Result<List<ContaDetalhesIdViewModel>>> ConsultarContas();
        Task<Result<List<ContaDetalhesIdViewModel>>> ConsultarContasInativadas();
        Task<Result<int>> CriarConta(ContaInputModel contaInputModel);
        Task<Result> Inativar(int id, string motivoExclusao);
        Task<Result> Ativar(int id);
        Task<Result> Atualizar(AtualizarContaInputModel atualizarContaInputModel);
        Task<Result<Conta>> ValidaContaExiste(int id);
    }
}
