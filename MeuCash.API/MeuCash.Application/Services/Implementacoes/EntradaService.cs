using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Constantes;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;

namespace MeuCash.Application.Services.Implementacoes
{
    public class EntradaService : IEntradaService
    {
        private readonly IEntradaRepository _entradaRepository;

        public EntradaService(IEntradaRepository entradaRepository)
        {
            _entradaRepository = entradaRepository;
        }

        public async Task<Result<EntradaDetalhesViewModel>> ConsultarEntradaPeloId(int id)
        {
            var entrada = await ValidaEntradaExiste(id: id);

            if (!entrada.IsSuccess)
                return Result<EntradaDetalhesViewModel>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            var entradaViewModel = new EntradaDetalhesViewModel
                (
                    id: entrada.Data.Id, 
                    idConta: entrada.Data.IdConta, 
                    valor: entrada.Data.Valor, 
                    data: entrada.Data.Data, 
                    descricao: entrada.Data.Descricao
                );

            return Result<EntradaDetalhesViewModel>.Success(entradaViewModel);
        }

        public async Task<Result<List<EntradasViewModel>>> ConsultarEntradasPeloIdConta(int idConta)
        {
            var conta = await ValidaEntradaExiste(id: idConta);

            if (!conta.IsSuccess)
                return Result<List<EntradasViewModel>>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            var entradas = await _entradaRepository.ConsultarEntradasPelaConta(idConta: conta.Data.Id);

            var entradasViewModel = entradas.Select(x => new EntradasViewModel(
                id: x.Id,
                idConta: x.IdConta,
                valor: x.Valor,
                data: x.Data
            )).ToList();

            return Result<List<EntradasViewModel>>.Success(entradasViewModel);
        }

        public async Task<Result<List<EntradasViewModel>>> ConsultarEntradas()
        {
            var entradas = await _entradaRepository.ConsultarEntradas();

            var entradasViewModel = entradas.Select(x => new EntradasViewModel(
                id: x.Id,
                idConta: x.IdConta,
                valor: x.Valor,
                data: x.Data
            )).ToList();

            return Result<List<EntradasViewModel>>.Success(entradasViewModel);
        }

        public async Task<Result<int>> CriarEntrada(EntradaInputModel entradaInputModel)
        {
            var novaEntrada = new Entrada
                (
                    idConta: entradaInputModel.IdConta,
                    valor: entradaInputModel.Valor,
                    data: entradaInputModel.Data,
                    descricao: entradaInputModel.Descricao
                );
            
            int id = await _entradaRepository.CriarEntrada(entrada: novaEntrada);
            return Result<int>.Success(id);
        }

        public async Task<Result> Inativar(int id, string motivoExclusao)
        {
            var entrada = await ValidaEntradaExiste(id: id);

            if (!entrada.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            if (!entrada.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroInativo);

            entrada.Data.Inativar(motivoExclusao: motivoExclusao);
            await _entradaRepository.Inativar();

            return Result.Sucesso();
        }

        public async Task<Result> Atualizar(AtualizarEntradaInputModel atualizarEntradaInputModel)
        {
            var entrada = await ValidaEntradaExiste(id: atualizarEntradaInputModel.Id);

            if (!entrada.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            await _entradaRepository.Atualizar(
                id: atualizarEntradaInputModel.Id,
                valor: atualizarEntradaInputModel.Valor,
                descricao: atualizarEntradaInputModel.Descricao);

            return Result.Sucesso();
        }

        public async Task<Result<List<EntradasViewModel>>> ConsultarEntradasInativadas()
        {
            var entradas = await _entradaRepository.ConsultarEntradasInativadas();

            var entradasViewModel = entradas.Select(x => new EntradasViewModel(
                id: x.Id,
                idConta: x.IdConta,
                valor: x.Valor,
                data: x.Data
            )).ToList();

            return Result<List<EntradasViewModel>>.Success(entradasViewModel);
        }

        public async Task<Result<Entrada>> ValidaEntradaExiste(int id)
        {
            var entrada = await _entradaRepository.ConsultarEntradaPeloId(id: id);

            if (entrada is null)
                return Result<Entrada>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);
            
            return Result<Entrada>.Success(entrada);
        }

        public async Task<Result> Ativar(int id)
        {
            var entrada = await ValidaEntradaExiste(id: id);

            if (!entrada.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            if (entrada.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroAtivo);

            entrada.Data.Ativar();
            await _entradaRepository.Ativar();

            return Result.Sucesso();
        }
    }
}
