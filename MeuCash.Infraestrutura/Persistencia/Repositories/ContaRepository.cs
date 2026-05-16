using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infraestrutura.Persistencia.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public ContaRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Conta> ConsultarContaPeloId(int id)
        {
            var conta = await _dbContext.Contas
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            return conta;
        }

        public async Task<List<Conta>> ConsultarContas()
        {
            var contas = await _dbContext.Contas
                .AsNoTracking()
                .ToListAsync();

            return contas;
        }

        public async Task CriarConta(Conta conta)
        {
            await _dbContext.Contas.AddAsync(conta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            //TODO: Eduardo Matheus Vaz | 14/05 | Estrutura como vai ser no caso de delete para não apagar demais objetos no banco
        }

        public async Task Update(int id, decimal novoSaldo)
        {
            var conta = await _dbContext.Contas
                .SingleOrDefaultAsync(x => x.Id == id);

            conta.AtualizarConta(saldoAtual: novoSaldo);

            await _dbContext.SaveChangesAsync();
        }
    }
}
