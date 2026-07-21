using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Constantes;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;

namespace MeuCash.Application.Services.Implementacoes
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<Result> Ativar(int id)
        {
            var conta = await ValidaContaExiste(id: id);

            if (!conta.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            if (conta.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroAtivo);

            conta.Data.Ativar();
            await _contaRepository.Ativar();

            return Result.Sucesso();
        }

        public async Task<Result> Atualizar(AtualizarContaInputModel atualizarContaInputModel)
        {
            var conta = await ValidaContaExiste(id: atualizarContaInputModel.Id);

            if (!conta.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            await _contaRepository.Atualizar(id: atualizarContaInputModel.Id, novoSaldo: atualizarContaInputModel.Saldo);
            return Result.Sucesso();
        }

        public async Task<Result<ContaDetalhesIdViewModel>> ConsultarContaPeloId(int id)
        {
            var conta = await _contaRepository.ConsultarContaPeloId(id: id);

            if (conta is null)
                return Result<ContaDetalhesIdViewModel>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            var contaViewModel = new ContaDetalhesIdViewModel
                (
                    idConta: conta.Id,
                    idUsuario: conta.IdUsuario,
                    nomeUsuario: conta.NomeUsuario,
                    saldoAtual: conta.SaldoAtual
                );

            return Result<ContaDetalhesIdViewModel>.Success(contaViewModel);
        }

        public async Task<Result<List<ContaDetalhesIdViewModel>>> ConsultarContas()
        {
            var contas = await _contaRepository.ConsultarContas();

            var contasViewModel = contas.Select(x => new ContaDetalhesIdViewModel(
                x.Id,
                x.IdUsuario,
                x.NomeUsuario,
                x.SaldoAtual)).ToList();

            return Result<List<ContaDetalhesIdViewModel>>.Success(contasViewModel);
        }

        public async Task<Result<List<ContaDetalhesIdViewModel>>> ConsultarContasInativadas()
        {
            var contas = await _contaRepository.ConsultarContasInativadas();

            var contasViewModel = contas.Select(x => new ContaDetalhesIdViewModel(
                x.Id,
                x.IdUsuario,
                x.NomeUsuario,
                x.SaldoAtual)).ToList();

            return Result<List<ContaDetalhesIdViewModel>>.Success(contasViewModel);
        }

        public async Task<Result<int>> CriarConta(ContaInputModel contaInputModel)
        {
            var contaNova = new Conta(idUsuario: contaInputModel.IdUsuario, saldoAtual: contaInputModel.SaldoAtual);

            int id = await _contaRepository.CriarConta(contaNova);
            return Result<int>.Success(id);
        }

        public async Task<Result> Inativar(int id, string motivoExclusao)
        {
            var conta = await ValidaContaExiste(id: id);

            if (!conta.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            if (!conta.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroInativo);

            conta.Data.Inativar(motivoExclusao: motivoExclusao);
            await _contaRepository.Inativar();

            return Result.Sucesso();
        }

        public async Task<Result<Conta>> ValidaContaExiste(int id)
        {
            var conta = await _contaRepository.ObtemConta(id: id);

            if (conta is null)
                return Result<Conta>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            return Result<Conta>.Success(conta);
        }
    }
}
