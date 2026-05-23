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
        Task Update(int id, int idConta, int idCategoria, decimal valor, DateTime dataDespesa, string descricao);
        Task Delete(int id);
    }
}
