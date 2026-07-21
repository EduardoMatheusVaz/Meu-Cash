using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IDespesaService
    {
        Task<Result<int>> CriarDespesa(DespesaInputModel despesaInputModel);
        Task<Result<DespesaDetalhesViewModel>> ConsultarDespesaPeloId(int id);
        Task<Result<List<DespesasViewModel>>> ConsultarDespesasPeloIdConta(int idConta);
        Task<Result<List<DespesasViewModel>>> ConsultarDespesas();
        Task<Result<List<DespesasViewModel>>> ConsultarDespesasInativadas();
        Task<Result> Inativar(int id, string motivoExclusao);
        Task<Result> Ativar(int id);
        Task<Result> Atualizar(AtualizarDespesaInputModel atualizarDespesaInputModel);
        Task<Result<Despesa>> ValidaDespesaExiste(int id);
    }
}
