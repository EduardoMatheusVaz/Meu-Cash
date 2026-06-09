using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IEntradaRepository
    {
        Task CriarEntrada(Entrada entrada);
        Task<Entrada> ConsultarEntradaPeloId(int id);
        Task<List<EntradasDTO>> ConsultarEntradas();
        Task<List<EntradasDTO>> ConsultarEntradasInativadas();
        Task<List<EntradasDTO>> ConsultarEntradasPelaConta(int idConta);
        Task Atualizar(int id, decimal valor, string descricao);
        Task Inativar(int id, string motivoExclusao);
    }
}
