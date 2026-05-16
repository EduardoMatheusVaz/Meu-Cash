using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infraestrutura.Persistencia.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public DespesaRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Despesa> ConsultarDespesaPeloId(int id)
        {
            var despesa = await _dbContext.Despesas
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            return despesa;
        }

        public async Task<List<Despesa>> ConsultarDespesaPeloIdConta(int id)
        {
            var despesas = await _dbContext.Despesas
                .Where(x => x.IdConta == id)
                .AsNoTracking()
                .ToListAsync();

            return despesas;
        }

        public async Task<List<Despesa>> ConsultarDespesas()
        {
            var despesas = await _dbContext.Despesas
                .AsNoTracking()
                .ToListAsync();

            return despesas;
        }

        public async Task CriarDespesa(Despesa despesa)
        {
            await _dbContext.Despesas.AddAsync(despesa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            //TODO: Eduardo Matheus Vaz | 14/05 | Estrutura como vai ser no caso de delete para não apagar demais objetos no banco
        }

        public async Task Update(int id, int idConta, int idCategoria, decimal valor, DateTime dataDespesa, string descricao)
        {
            var despesa = await _dbContext.Despesas
                .SingleOrDefaultAsync(x => x.Id == id);

            despesa.AtualizarDespesa(
                    idConta: idConta,
                    idCategoria: idCategoria,
                    valor: valor,
                    dataDespesa: dataDespesa,
                    descricao: descricao);

            await _dbContext.SaveChangesAsync();
        }
    }
}
