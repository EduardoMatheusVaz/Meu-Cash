using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface ICategoriaRepository
    {
        Task CriarCategoria(Categoria categoria);
        Task<Categoria> ConsultarCategoriaPeloId(int id);
        Task<List<Categoria>> ConsultarCategorias();
        Task Update(int id, string nome);
        Task Delete(int id);
    }
}
