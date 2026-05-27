using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IEntradaRepository
    {
        Task CriarEntrada(Entrada entrada);
        Task<Entrada> ConsultarEntradaPeloId(int id);
        Task<List<EntradasDTO>> ConsultarEntradas();
        Task<List<EntradasDTO>> ConsultarEntradasPelaConta(int idConta);
        Task Update(int idConta, decimal valor, DateTime dataEntrada, string descricao);
        Task Delete(int id);
    }
}
