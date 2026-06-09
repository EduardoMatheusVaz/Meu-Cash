using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IContaRepository
    {
        Task CriarConta(Conta conta);
        Task<ContaDetalhesIdDTO> ConsultarContaPeloId(int id);
        Task<List<ContaDetalhesIdDTO>> ConsultarContas();
        Task<List<ContaDetalhesIdDTO>> ConsultarContasInativadas();
        Task Inativar(int id, string motivoExclusao);
        Task Atualizar(int id, decimal novoSaldo);
    }
}
