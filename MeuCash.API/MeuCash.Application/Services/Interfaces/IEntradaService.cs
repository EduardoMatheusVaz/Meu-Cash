using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IEntradaService
    {
        Task<Result<int>> CriarEntrada(EntradaInputModel entradaInputModel);
        Task<Result<EntradaDetalhesViewModel>> ConsultarEntradaPeloId(int id);
        Task<Result<List<EntradasViewModel>>> ConsultarEntradasPeloIdConta(int idConta);
        Task<Result<List<EntradasViewModel>>> ConsultarEntradas();
        Task<Result<List<EntradasViewModel>>> ConsultarEntradasInativadas();
        Task<Result> Inativar(int id, string motivoExclusao);
        Task<Result> Ativar(int id);
        Task<Result> Atualizar(AtualizarEntradaInputModel atualizarEntradaInputModel);
        Task<Result<Entrada>> ValidaEntradaExiste(int id); 
    }
}
