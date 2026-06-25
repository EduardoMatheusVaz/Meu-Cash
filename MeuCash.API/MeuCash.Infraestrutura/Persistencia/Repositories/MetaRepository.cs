using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infraestrutura.Persistencia.Repositories
{
    public class MetaRepository : IMetasRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public MetaRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MetaDetalhesDTO> ConsultarMetaPeloId(int id)
        {
            var meta = await _dbContext.Metas
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            var metaDTO = new MetaDetalhesDTO
                (
                    id: meta.Id,
                    nome: meta.Nome,
                    descricao: meta.Descricao,
                    idUsuario: meta.IdUsuario,
                    idConta: meta.IdConta,
                    valor: meta.Valor,
                    dataCriacao: meta.DataCriacao,
                    dataLimite: meta.DataLimite
                );

            return metaDTO;
        }

        public async Task<List<MetasDTO>> ConsultarMetas()
        {
            var metas = await _dbContext.Metas
                .Where(x => x.Ativo)
                .AsNoTracking()
                .ToListAsync();

            var metasDTO = metas.Select(x => new MetasDTO
            (
                id: x.Id,
                nome: x.Nome,
                idConta: x.IdConta,
                valor: x.Valor
                )).ToList();

            return metasDTO;
        }

        public async Task<List<MetasDTO>> ConsultarMetasPelaConta(int idConta)
        {
            var metas = await _dbContext.Metas
                .Where(x => x.IdConta == idConta)
                .AsNoTracking()
                .ToListAsync();

            var metasDTO = metas.Select(x => new MetasDTO
            (
                id: x.Id,
                nome: x.Nome,
                idConta: x.IdConta,
                valor: x.Valor
                )).ToList();

            return metasDTO;
        }

        public async Task CriarMeta(Meta meta)
        {
            await _dbContext.Metas.AddAsync(meta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Inativar()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(int id, string nome, string descricao, decimal valor, DateTime dataLimite)
        {
            var meta = await _dbContext.Metas
                .SingleOrDefaultAsync(x => x.Id == id);

            meta.AtualizarMeta(
                nome: nome,
                descricao: descricao,
                valor: valor,
                dataLimite: dataLimite);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MetasDTO>> ConsultarMetasInativadas()
        {
            var metas = await _dbContext.Metas
                .Where(x => !x.Ativo)
                .AsNoTracking()
                .ToListAsync();

            var metasDTO = metas.Select(x => new MetasDTO
            (
                id: x.Id,
                nome: x.Nome,
                idConta: x.IdConta,
                valor: x.Valor
                )).ToList();

            return metasDTO;
        }

        public async Task<Meta> ConsultarMetaExiste(int id)
        {
            var meta = await _dbContext.Metas
                .SingleOrDefaultAsync(x => x.Id == id);

            return meta;
        }

        public async Task Ativar(Meta meta)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
