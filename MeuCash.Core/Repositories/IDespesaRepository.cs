using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IDespesaRepository
    {
        Task CriarDespesa(Despesa despesa);
        Task<Despesa> ConsultarDespesaPeloId(int id);
        Task<List<Despesa>> ConsultarDespesaPeloIdConta(int id);
        Task<List<Despesa>> ConsultarDespesas();
        Task Update(int id, int idConta, int idCategoria, decimal valor, DateTime dataDespesa, string descricao);
        Task Delete(int id);
    }
}
