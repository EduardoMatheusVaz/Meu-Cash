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

        public async Task<Meta> ConsultarMetaPeloId(int id)
        {
            var meta = await _dbContext.Metas
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            return meta;
        }

        public async Task<List<Meta>> ConsultarMetas()
        {
            var metas = await _dbContext.Metas
                .AsNoTracking()
                .ToListAsync();

            return metas;
        }

        public async Task<List<Meta>> ConsultarMetasPelaConta(int idConta)
        {
            var metas = await _dbContext.Metas
                .Where(x => x.IdConta == idConta)
                .AsNoTracking()
                .ToListAsync();

            return metas;
        }

        public async Task CriarMeta(Meta meta)
        {
            await _dbContext.Metas.AddAsync(meta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            //TODO: Eduardo Matheus Vaz | 14/05 | Estrutura como vai ser no caso de delete para não apagar demais objetos no banco
        }

        public async Task Update(int id, string nome, string descricao, int idUsuario, int idConta, decimal valor, DateTime dataLimite)
        {
            var meta = await _dbContext.Metas
                .SingleOrDefaultAsync(x => x.Id == id);

            meta.AtualizarMeta(
                nome: nome,
                descricao: descricao,
                idUsuario: idUsuario,
                idConta: idConta,
                valor: valor,
                dataLimite: dataLimite);

            await _dbContext.SaveChangesAsync();
        }
    }
}
