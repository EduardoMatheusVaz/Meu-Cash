using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
using MeuCash.Core.Exceptions;
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

        public async Task Ativar(int id)
        {
            var conta = await ValidaContaExiste(id: id);

            if (conta.Ativo)
                throw new ContaAtivaException(id: id);

            conta.Ativar();

            await _contaRepository.Ativar(conta: conta);
        }

        public async Task Atualizar(AtualizarContaInputModel atualizarContaInputModel)
        {
            var conta = await ValidaContaExiste(id: atualizarContaInputModel.Id);

            await _contaRepository.Atualizar(id: atualizarContaInputModel.Id, novoSaldo: atualizarContaInputModel.Saldo);
        }

        public async Task<ContaDetalhesIdViewModel> ConsultarContaPeloId(int id)
        {
            var conta = await _contaRepository.ConsultarContaPeloId(id: id);

            if (conta is null)
                throw new ContaNaoEncontradaException(id: id);

            var contaViewModel = new ContaDetalhesIdViewModel
                (
                    idConta: conta.Id,
                    idUsuario: conta.IdUsuario,
                    nomeUsuario: conta.NomeUsuario,
                    saldoAtual: conta.SaldoAtual
                );

            return contaViewModel;
        }

        public async Task<List<ContaDetalhesIdViewModel>> ConsultarContas()
        {
            var contas = await _contaRepository.ConsultarContas();

            var contasViewModel = contas.Select(x => new ContaDetalhesIdViewModel(
                x.Id,
                x.IdUsuario,
                x.NomeUsuario,
                x.SaldoAtual)).ToList();

            return contasViewModel;
        }

        public async Task<List<ContaDetalhesIdViewModel>> ConsultarContasInativadas()
        {
            var contas = await _contaRepository.ConsultarContasInativadas();

            var contasViewModel = contas.Select(x => new ContaDetalhesIdViewModel(
                x.Id,
                x.IdUsuario,
                x.NomeUsuario,
                x.SaldoAtual)).ToList();

            return contasViewModel;
        }

        public async Task CriarConta(ContaInputModel contaInputModel)
        {
            var contaNova = new Conta(idUsuario: contaInputModel.IdUsuario, saldoAtual: contaInputModel.SaldoAtual);

            await _contaRepository.CriarConta(contaNova);
        }

        public async Task Inativar(int id, string motivoExclusao)
        {
            var conta = await ValidaContaExiste(id: id);

            if (!conta.Ativo)
                throw new ContaInativaException(id: id);

            conta.Inativar(motivoExclusao: motivoExclusao);

            await _contaRepository.Inativar();
        }

        public async Task<Conta> ValidaContaExiste(int id)
        {
            var conta = await _contaRepository.ObtemConta(id: id);

            if (conta is null)
                throw new ContaNaoEncontradaException(id: id);

            return conta;
        }
    }
}
