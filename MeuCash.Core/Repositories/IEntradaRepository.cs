using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IEntradaRepository
    {
        Task CriarEntrada(Entrada entrada);
        Task<Entrada> ConsultarEntradaPeloId(int id);
        Task<List<Entrada>> ConsultarEntradas();
        Task<List<Entrada>> ConsultarEntradasPelaConta(int idConta);
        Task Update(int idConta, decimal valor, DateTime dataEntrada, string descricao);
        Task Delete(int id);
    }
}
