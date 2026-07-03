using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
using MeuCash.Core.Exceptions;
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

        public async Task Ativar(int id)
        {
            var categoria = await ValidaCategoriaExiste(id: id);

            if (categoria.Ativo)
                throw new EntidadeAtivaException(id: id);

            categoria.Ativar();

            await _categoriaRepository.Ativar(categoria: categoria);
        }

        public async Task Atualizar(AtualizarCategoriaInputModel atualizarCategoriaInputModel)
        {
            var categoria = await ValidaCategoriaExiste(atualizarCategoriaInputModel.Id);

            await _categoriaRepository.Atualizar(id: atualizarCategoriaInputModel.Id, nome: atualizarCategoriaInputModel.Nome);
        }

        public async Task<CategoriaViewModel> ConsultarCategoriaPeloId(int id)
        {
            var categoria = await _categoriaRepository
                .ConsultarCategoriaPeloId(id: id);

            if (categoria is null)
                throw new RegistroIdEncontradoException(id: id);

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

        public async Task<List<CategoriaViewModel>> ConsultarCategoriasInativadas()
        {
            var categorias = await _categoriaRepository.ConsultarCategoriasInativadas();

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

        public async Task Inativar(int id, string motivoExclusao)
        {
            var categoria = await ValidaCategoriaExiste(id: id);

            if (!categoria.Ativo)
                throw new EntidadeInativaException(id: id);

            categoria.Inativar(motivoExclusao: motivoExclusao);

            await _categoriaRepository.Inativar();
        }

        public async Task<Categoria> ValidaCategoriaExiste(int id)
        {
            var categoria = await _categoriaRepository.ConsultarCategoriaPeloId(id: id);

            if (categoria is null)
                throw new RegistroIdEncontradoException(id: id);

            return categoria;
        }
    }
}
