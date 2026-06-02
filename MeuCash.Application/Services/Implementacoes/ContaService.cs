using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
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

        public async Task<ContaDetalhesIdViewModel> ConsultarContaPeloId(int id)
        {
            var conta = await _contaRepository.ConsultarContaPeloId(id: id);

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

        public async Task CriarConta(ContaInputModel contaInputModel)
        {
            var contaNova = new Conta(idUsuario: contaInputModel.IdUsuario, saldoAtual: contaInputModel.SaldoAtual);

            await _contaRepository.CriarConta(contaNova);
        }
    }
}
