using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface ICategoriaRepository
    {
        Task<int> CriarCategoria(Categoria categoria);
        Task<Categoria> ConsultarCategoriaPeloId(int id);
        Task<List<Categoria>> ConsultarCategorias();
        Task<List<Categoria>> ConsultarCategoriasInativadas();
        Task Inativar();
        Task Ativar(Categoria categoria);
        Task Atualizar(int id, string nome);
    }
}
