using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IDespesaService
    {
        Task CriarDespesa(DespesaInputModel despesaInputModel);
        Task<DespesaDetalhesViewModel> ConsultarDespesaPeloId(int id);
        Task<List<DespesasViewModel>> ConsultarDespesasPeloIdConta(int idConta);
        Task<List<DespesasViewModel>> ConsultarDespesas();
        Task<List<DespesasViewModel>> ConsultarDespesasInativadas();
        Task Inativar(int id, string motivoExclusao);
        Task Ativar(int id);
        Task Atualizar(AtualizarDespesaInputModel atualizarDespesaInputModel);
        Task<Despesa> ValidaDespesaExiste(int id);
    }
}
