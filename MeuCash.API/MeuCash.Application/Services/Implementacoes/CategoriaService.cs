using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Constantes;
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

        public async Task<Result> Ativar(int id)
        {
            var categoria = await ValidaCategoriaExiste(id: id);

            if (!categoria.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            if (categoria.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroAtivo);

            categoria.Data.Ativar();
            await _categoriaRepository.Ativar(categoria: categoria.Data);
            
            return Result.Sucesso();
        }

        public async Task<Result> Atualizar(AtualizarCategoriaInputModel atualizarCategoriaInputModel)
        {
            var categoria = await ValidaCategoriaExiste(atualizarCategoriaInputModel.Id);

            if (!categoria.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            await _categoriaRepository.Atualizar(id: atualizarCategoriaInputModel.Id, nome: atualizarCategoriaInputModel.Nome);
            return Result.Sucesso();
        }

        public async Task<Result<CategoriaViewModel>> ConsultarCategoriaPeloId(int id)
        {
            var categoria = await _categoriaRepository
                .ConsultarCategoriaPeloId(id: id);

            if (categoria is null)
                return Result<CategoriaViewModel>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            var categoriaViewModel = new CategoriaViewModel
                (
                    id: categoria.Id, 
                    nome: categoria.Nome
                );

            return Result<CategoriaViewModel>.Success(categoriaViewModel);
        }

        public async Task<Result<List<CategoriaViewModel>>> ConsultarCategorias()
        {
            var categorias = await _categoriaRepository.ConsultarCategorias();

            var categoriasViewModel = categorias
                .Select(x => new CategoriaViewModel(id: x.Id, nome: x.Nome))
                .ToList();

            return Result<List<CategoriaViewModel>>.Success(categoriasViewModel);
        }

        public async Task<Result<List<CategoriaViewModel>>> ConsultarCategoriasInativadas()
        {
            var categorias = await _categoriaRepository.ConsultarCategoriasInativadas();

            var categoriasViewModel = categorias
                .Select(x => new CategoriaViewModel(id: x.Id, nome: x.Nome))
                .ToList();

            return Result<List<CategoriaViewModel>>.Success(categoriasViewModel);
        }

        public async Task<Result<int>> CriarCategoria(CategoriaInputModel categoriaInputModel)
        {
            var novaCategoria = new Categoria(nome: categoriaInputModel.Nome);

            int id = await _categoriaRepository.CriarCategoria(categoria: novaCategoria);
            return Result<int>.Success(id);
        }

        public async Task<Result> Inativar(int id, string motivoExclusao)
        {
            var categoria = await ValidaCategoriaExiste(id: id);

            if (!categoria.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroInativo);

            if (!categoria.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroInativo);

            categoria.Data.Inativar(motivoExclusao: motivoExclusao);
            await _categoriaRepository.Inativar();

            return Result.Sucesso();
        }

        public async Task<Result<Categoria>> ValidaCategoriaExiste(int id)
        {
            var categoria = await _categoriaRepository.ConsultarCategoriaPeloId(id: id);

            if (categoria is null)
                return Result<Categoria>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            return Result<Categoria>.Success(categoria);
        }
    }
}
