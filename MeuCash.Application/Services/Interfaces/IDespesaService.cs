using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IDespesaService
    {
        Task CriarDespesa(DespesaInputModel despesaInputModel);
        Task<DespesaDetalhesViewModel> ConsultarDespesaPeloId(int id);
        Task<List<DespesasViewModel>> ConsultarDespesasPeloIdConta(int idConta);
        Task<List<DespesasViewModel>> ConsultarDespesas();
    }
}
