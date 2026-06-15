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
        Task Inativar();
        Task Ativar(Conta conta);
        Task Atualizar(int id, decimal novoSaldo);
        Task<Conta> ObtemConta(int id);
    }
}
