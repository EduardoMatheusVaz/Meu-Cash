using Dapper;
using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;
using MeuCash.Infraestrutura.Persistencia.Queries.Conta;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MeuCash.Infraestrutura.Persistencia.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly MeuCashDbContext _dbContext;
        private readonly string _connectionString;

        public ContaRepository(MeuCashDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("MeuCash");
        }

        public async Task<ContaDetalhesIdDTO> ConsultarContaPeloId(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var query = ContaQueries.ObtemContaPeloId(id: id);

                var conta = await sqlConnection.QuerySingleOrDefaultAsync<ContaDetalhesIdDTO>(query);

                return conta;
            }
            //    var conta = await _dbContext.Contas
            //        .AsNoTracking()
            //        .SingleOrDefaultAsync(x => x.Id == id);

            //return conta;
        }

        public async Task<List<ContaDetalhesIdDTO>> ConsultarContas()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var query = ContaQueries.ObtemContas();

                return (await sqlConnection.QueryAsync<ContaDetalhesIdDTO>(query)).AsList();
                
                //var contas = await sqlConnection.QueryAsync<List<ContaDetalhesIdDTO>>(query);
                //return contas;
            }

            //var contas = await _dbContext.Contas
            //    .AsNoTracking()
            //    .ToListAsync();

            //return contas;
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
