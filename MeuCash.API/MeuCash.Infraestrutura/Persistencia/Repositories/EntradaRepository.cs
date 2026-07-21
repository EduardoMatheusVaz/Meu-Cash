using MeuCash.Core.DTOs;
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
                .SingleOrDefaultAsync(x => x.Id == id);

            return entrada;
        }

        public async Task<List<EntradasDTO>> ConsultarEntradas()
        {
            var entradas = await _dbContext.Entradas
                .Where(x => x.Ativo)
                .AsNoTracking()
                .ToListAsync();

            var entradasDTO = entradas.Select(x => new EntradasDTO
            (
                id: x.Id,
                idConta: x.IdConta,
                valor: x.Valor,
                data: x.Data
            )).ToList();

            return entradasDTO;
        }

        public async Task<List<EntradasDTO>> ConsultarEntradasPelaConta(int idConta)
        {
            var entradas = await _dbContext.Entradas
                .Where(x => x.IdConta == idConta)
                .AsNoTracking()
                .ToListAsync();

            var entradasDTO = entradas.Select(x => new EntradasDTO
            (
                id: x.Id,
                idConta: x.IdConta,
                valor: x.Valor,
                data: x.Data
            )).ToList();

            return entradasDTO;
        }

        public async Task<int> CriarEntrada(Entrada entrada)
        {
            await _dbContext.Entradas.AddAsync(entrada);
            await _dbContext.SaveChangesAsync();
            
            return entrada.Id;
        }

        public async Task Inativar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(int id, decimal valor, string descricao)
        {
            var entrada = await _dbContext.Entradas
                .SingleOrDefaultAsync(x => x.Id == id);

            entrada.AtualizarEntrada(
                valor: valor,
                descricao: descricao);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<EntradasDTO>> ConsultarEntradasInativadas()
        {
            var entradas = await _dbContext.Entradas
                .Where(x => !x.Ativo)
                .AsNoTracking()
                .ToListAsync();

            var entradasDTO = entradas.Select(x => new EntradasDTO
            (
                id: x.Id,
                idConta: x.IdConta,
                valor: x.Valor,
                data: x.Data
            )).ToList();

            return entradasDTO;
        }

        public async Task Ativar()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
