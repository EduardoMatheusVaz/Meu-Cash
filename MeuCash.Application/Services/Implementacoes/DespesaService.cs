using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
using MeuCash.Core.Exceptions;
using MeuCash.Core.Repositories;

namespace MeuCash.Application.Services.Implementacoes
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;

        public DespesaService(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public async Task<DespesaDetalhesViewModel> ConsultarDespesaPeloId(int id)
        {
            var despesa = await _despesaRepository.ConsultarDespesaPeloId(id: id);

            var despesaViewModel = new DespesaDetalhesViewModel
                (
                    id: despesa.Id,
                    idConta: despesa.IdConta,
                    nomeCategoria: despesa.NomeCategoria,
                    valor: despesa.Valor,
                    dataDespesa: despesa.DataDespesa,
                    descricao: despesa.Descricao
                );

            return despesaViewModel;
        }

        public async Task<List<DespesasViewModel>> ConsultarDespesasPeloIdConta(int idConta)
        {
            var despesas = await _despesaRepository.ConsultarDespesasPeloIdConta(id: idConta);

            if (despesas is null)
                throw new DespesaIdContaNaoEncontradaException(id: idConta);

            var despesasViewModel = despesas.Select(x => new DespesasViewModel(
                x.Id,
                x.IdConta,
                x.Valor,
                x.DataDespesa)).ToList();

            return despesasViewModel;
        }

        public async Task<List<DespesasViewModel>> ConsultarDespesas()
        {
            var despesas = await _despesaRepository.ConsultarDespesas();

            var despesasViewModel = despesas.Select(x => new DespesasViewModel(
                x.Id,
                x.IdConta,
                x.Valor,
                x.DataDespesa)).ToList();

            return despesasViewModel;
        }

        public async Task CriarDespesa(DespesaInputModel despesaInputModel)
        {
            var novaDespesa = new Despesa
                (
                    idConta: despesaInputModel.IdConta, 
                    idCategoria: despesaInputModel.IdCategoria, 
                    valor: despesaInputModel.Valor, 
                    descricao: despesaInputModel.Descricao
                );

            await _despesaRepository.CriarDespesa(novaDespesa);
        }

        public async Task Inativar(int id, string motivoExclusao)
        {
            var despesa = await ValidaDespesaExiste(id: id);

            if (!despesa.Ativo)
                throw new DespesaInativaException(id: id);

            despesa.Inativar(motivoExclusao: motivoExclusao);

            await _despesaRepository.Inativar();
        }

        public async Task Atualizar(AtualizarDespesaInputModel atualizarDespesaInputModel)
        {
            var despesa = await ValidaDespesaExiste(id: atualizarDespesaInputModel.Id);

            await _despesaRepository.Atualizar(
                id: atualizarDespesaInputModel.Id,
                idCategoria: atualizarDespesaInputModel.IdCategoria,
                valor: atualizarDespesaInputModel.Valor,
                descricao: atualizarDespesaInputModel.Descricao
            );
        }

        public async Task<List<DespesasViewModel>> ConsultarDespesasInativadas()
        {
            var despesas = await _despesaRepository.ConsultarDespesasInativadas();

            var despesasViewModel = despesas.Select(x => new DespesasViewModel(
                x.Id,
                x.IdConta,
                x.Valor,
                x.DataDespesa)).ToList();

            return despesasViewModel;
        }

        public async Task<Despesa> ValidaDespesaExiste(int id)
        {
            var despesa = await _despesaRepository.ObtemDespesa(id: id);

            if (despesa is null)
                throw new DespesaNaoEncontradaException(id: id);

            return despesa;
        }

        public async Task Ativar(int id)
        {
            var despesa = await ValidaDespesaExiste(id: id);

            if (despesa.Ativo)
                throw new DespesaAtivaException(id: id);

            despesa.Ativar();

            await _despesaRepository.Ativar(despesa: despesa);
        }
    }
}
