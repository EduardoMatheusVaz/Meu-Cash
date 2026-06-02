using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;

namespace MeuCash.Application.Services.Implementacoes
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaViewModel> ConsultarCategoriaPeloId(int id)
        {
            var categoria = await _categoriaRepository
                .ConsultarCategoriaPeloId(id: id);
            
            var categoriaViewModel = new CategoriaViewModel
                (
                    id: categoria.Id, 
                    nome: categoria.Nome
                );

            return categoriaViewModel;
        }

        public async Task<List<CategoriaViewModel>> ConsultarCategorias()
        {
            var categorias = await _categoriaRepository.ConsultarCategorias();

            var categoriasViewModel = categorias
                .Select(x => new CategoriaViewModel
                (
                    id: x.Id,
                    nome: x.Nome)
                ).ToList();

            return categoriasViewModel;
        }

        public async Task CriarCategoria(CategoriaInputModel categoriaInputModel)
        {
            var novaCategoria = new Categoria(nome: categoriaInputModel.Nome);

            await _categoriaRepository.CriarCategoria(categoria: novaCategoria);
        }
    }
}
