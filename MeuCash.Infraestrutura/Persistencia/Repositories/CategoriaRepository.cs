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

        public async Task<Categoria> ConsultarCategoriaPeloId(int id)
        {
            var categoria = await _dbContext.Categorias
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            return categoria;
        }

        public async Task<List<Categoria>> ConsultarCategorias()
        {
            var categorias = await _dbContext.Categorias
                .AsNoTracking()
                .ToListAsync();

            return categorias;
        }

        public async Task CriarCategoria(Categoria categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            //TODO: Eduardo Matheus Vaz | 14/05 | Estrutura como vai ser no caso de delete para não apagar demais objetos no banco
        }

        public async Task Update(int id, string nome)
        {
            var categoria = await _dbContext.Categorias
                .SingleOrDefaultAsync(x => x.Id == id);

            categoria.AtualizarCategoria(nomeCategoria: nome);

            await _dbContext.SaveChangesAsync();
        }
    }
}
