using MeuCash.Core.DTOs.Despesa;
using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IDespesaRepository
    {
        Task CriarDespesa(Despesa despesa);
        Task<DespesaDetalhesDTO> ConsultarDespesaPeloId(int id);
        Task<List<DespesasDTO>> ConsultarDespesasPeloIdConta(int id);
        Task<List<DespesasDTO>> ConsultarDespesas();
        Task<List<DespesasDTO>> ConsultarDespesasInativadas();
        Task Atualizar(int id, int idCategoria, decimal valor, string descricao);
        Task Inativar(int id, string motivoExclusao);
    }
}
