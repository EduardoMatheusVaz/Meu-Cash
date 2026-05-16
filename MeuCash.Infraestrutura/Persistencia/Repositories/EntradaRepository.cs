using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infraestrutura.Persistencia.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public EntradaRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Entrada> ConsultarEntradaPeloId(int id)
        {
            var entrada = await _dbContext.Entradas
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            return entrada;
        }

        public async Task<List<Entrada>> ConsultarEntradas()
        {
            var entradas = await _dbContext.Entradas
                .AsNoTracking()
                .ToListAsync();

            return entradas;
        }

        public async Task<List<Entrada>> ConsultarEntradasPelaConta(int idConta)
        {
            var entradas = await _dbContext.Entradas
                .Where(x => x.IdConta == idConta)
                .AsNoTracking()
                .ToListAsync();

            return entradas;
        }

        public async Task CriarEntrada(Entrada entrada)
        {
            await _dbContext.Entradas.AddAsync(entrada);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            //TODO: Eduardo Matheus Vaz | 14/05 | Estrutura como vai ser no caso de delete para não apagar demais objetos no banco
        }

        public async Task Update(int idConta, decimal valor, DateTime dataEntrada, string descricao)
        {
            var entrada = await _dbContext.Entradas
                .SingleOrDefaultAsync(x => x.Id == idConta);

            entrada.AtualizarEntrada(
                idConta:  idConta,
                valor: valor,
                dataEntrada: dataEntrada,
                descricao: descricao);

            await _dbContext.SaveChangesAsync();
        }
    }
}
