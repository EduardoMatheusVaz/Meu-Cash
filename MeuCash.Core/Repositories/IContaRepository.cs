using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IContaRepository
    {
        Task CriarConta(Conta conta);
        Task<Conta> ConsultarContaPeloId(int id);
        Task<List<Conta>> ConsultarContas();
        Task Update(int id, decimal novoSaldo);
        Task Delete(int id);
    }
}
