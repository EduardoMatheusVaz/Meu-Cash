using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;

namespace MeuCash.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaViewModel> ConsultarCategoriaPeloId(int id);
        Task<List<CategoriaViewModel>> ConsultarCategorias();
        Task CriarCategoria(CategoriaInputModel categoriaInputModel);

    }
}
