using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IContaRepository
    {
        Task CriarConta(Conta conta);
        Task<ContaDetalhesIdDTO> ConsultarContaPeloId(int id);
        Task<List<ContaDetalhesIdDTO>> ConsultarContas();
        Task Update(int id, decimal novoSaldo);
        Task Delete(int id);
    }
}
