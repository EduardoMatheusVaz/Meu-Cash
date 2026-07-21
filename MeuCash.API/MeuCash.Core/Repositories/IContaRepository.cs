using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IContaRepository
    {
        Task<int> CriarConta(Conta conta);
        Task<ContaDetalhesIdDTO> ConsultarContaPeloId(int id);
        Task<List<ContaDetalhesIdDTO>> ConsultarContas();
        Task<List<ContaDetalhesIdDTO>> ConsultarContasInativadas();
        Task Inativar();
        Task Ativar();
        Task Atualizar(int id, decimal novoSaldo);
        Task<Conta> ObtemConta(int id);
    }
}
