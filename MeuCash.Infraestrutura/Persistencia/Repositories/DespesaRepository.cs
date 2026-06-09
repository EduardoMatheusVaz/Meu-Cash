using Dapper;
using MeuCash.Core.DTOs.Despesa;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;
using MeuCash.Infraestrutura.Persistencia.Queries.Despesa;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MeuCash.Infraestrutura.Persistencia.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly MeuCashDbContext _dbContext;
        private readonly string _connectionString;

        public DespesaRepository(MeuCashDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("MeuCash");
        }

        public async Task<DespesaDetalhesDTO> ConsultarDespesaPeloId(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var query = DespesasQueries.ObtemDespesaPeloId(id: id);

                var despesa = await sqlConnection.QuerySingleOrDefaultAsync<DespesaDetalhesDTO>(query);

                return despesa;
            }
            //var despesa = await _dbContext.Despesas
            //    .AsNoTracking()
            //    .SingleOrDefaultAsync(x => x.Id == id);

            //return despesa;
        }

        public async Task<List<DespesasDTO>> ConsultarDespesasPeloIdConta(int id)
        {
            var despesas = await _dbContext.Despesas
                .Where(x => x.IdConta == id)
                .AsNoTracking()
                .ToListAsync();

            var despesasDTO = despesas.Select(x => new DespesasDTO
            (
                x.Id,
                x.IdConta,
                x.Valor,
                x.DataDespesa)).ToList();

            return despesasDTO;
        }

        public async Task<List<DespesasDTO>> ConsultarDespesas()
        {
            var despesas = await _dbContext.Despesas
                .Where(x => x.Ativo)
                .AsNoTracking()
                .ToListAsync();

            var despesasDTO = despesas.Select(x => new DespesasDTO
            (
                x.Id,
                x.IdConta,
                x.Valor,
                x.DataDespesa)).ToList();

            return despesasDTO;
        }

        public async Task CriarDespesa(Despesa despesa)
        {
            await _dbContext.Despesas.AddAsync(despesa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Inativar(int id, string motivoExclusao)
        {
            var despesa = await _dbContext.Despesas.SingleOrDefaultAsync(x => x.Id == id);

            despesa.Inativar(motivoExclusao:  motivoExclusao);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(int id, int idCategoria, decimal valor, string descricao)
        {
            var despesa = await _dbContext.Despesas
                .SingleOrDefaultAsync(x => x.Id == id);

            despesa.AtualizarDespesa
                (
                    idCategoria: idCategoria,
                    valor: valor,
                    descricao: descricao
                );

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<DespesasDTO>> ConsultarDespesasInativadas()
        {
            var despesas = await _dbContext.Despesas
                .Where(x => !x.Ativo)
                .AsNoTracking()
                .ToListAsync();

            var despesasDTO = despesas.Select(x => new DespesasDTO
            (
                x.Id,
                x.IdConta,
                x.Valor,
                x.DataDespesa)).ToList();

            return despesasDTO;
        }
    }
}
