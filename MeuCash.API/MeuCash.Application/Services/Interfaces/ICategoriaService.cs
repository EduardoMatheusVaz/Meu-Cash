using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaViewModel> ConsultarCategoriaPeloId(int id);
        Task<List<CategoriaViewModel>> ConsultarCategorias();
        Task<List<CategoriaViewModel>> ConsultarCategoriasInativadas();
        Task CriarCategoria(CategoriaInputModel categoriaInputModel);
        Task Inativar(int id, string motivoExclusao);
        Task Ativar(int id);
        Task Atualizar(AtualizarCategoriaInputModel atualizarCategoriaInputModel);
        Task<Categoria> ValidaCategoriaExiste(int id);
    }
}
