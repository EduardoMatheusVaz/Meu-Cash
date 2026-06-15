using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infraestrutura.Persistencia.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public CategoriaRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Ativar(Categoria categoria)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(int id, string nome)
        {
            var categoria = await _dbContext.Categorias.SingleOrDefaultAsync(x => x.Id == id);

            categoria.AtualizarCategoria(nomeCategoria: nome);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Categoria> ConsultarCategoriaPeloId(int id)
        {
            var categoria = await _dbContext.Categorias
                .SingleOrDefaultAsync(x => x.Id == id);

            return categoria;
        }

        public async Task<List<Categoria>> ConsultarCategorias()
        {
            var categorias = await _dbContext.Categorias
                .Where(x => x.Ativo)
                .AsNoTracking()
                .ToListAsync();

            return categorias;
        }

        public async Task<List<Categoria>> ConsultarCategoriasInativadas()
        {
            var categorias = await _dbContext.Categorias
                .Where(x => !x.Ativo)
                .AsNoTracking()
                .ToListAsync();

            return categorias;
        }

        public async Task CriarCategoria(Categoria categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Inativar()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
