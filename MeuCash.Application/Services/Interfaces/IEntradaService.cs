using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IEntradaService
    {
        Task CriarEntrada(EntradaInputModel entradaInputModel);
        Task<EntradaDetalhesViewModel> ConsultarEntradaPeloId(int id);
        Task<List<EntradasViewModel>> ConsultarEntradasPeloIdConta(int idConta);
        Task<List<EntradasViewModel>> ConsultarEntradas();
        Task<List<EntradasViewModel>> ConsultarEntradasInativadas();
        Task Inativar(int id, string motivoExclusao);
        Task Ativar(int id);
        Task Atualizar(AtualizarEntradaInputModel atualizarEntradaInputModel);
        Task<Entrada> ValidaEntradaExiste(int id); 
    }
}
