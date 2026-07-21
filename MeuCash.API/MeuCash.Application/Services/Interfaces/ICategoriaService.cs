using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<Result<CategoriaViewModel>> ConsultarCategoriaPeloId(int id);
        Task<Result<List<CategoriaViewModel>>> ConsultarCategorias();
        Task<Result<List<CategoriaViewModel>>> ConsultarCategoriasInativadas();
        Task<Result<int>> CriarCategoria(CategoriaInputModel categoriaInputModel);
        Task<Result> Inativar(int id, string motivoExclusao);
        Task<Result> Ativar(int id);
        Task<Result> Atualizar(AtualizarCategoriaInputModel atualizarCategoriaInputModel);
        Task<Result<Categoria>> ValidaCategoriaExiste(int id);
    }
}
