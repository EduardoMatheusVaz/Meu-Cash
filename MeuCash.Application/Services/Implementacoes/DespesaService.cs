using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
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
                    idCategoria: despesaInputModel.IdConta, 
                    valor: despesaInputModel.Valor, 
                    dataDespesa: despesaInputModel.DataDespesa, 
                    descricao: despesaInputModel.Descricao
                );

            await _despesaRepository.CriarDespesa(novaDespesa);
        }
    }
}
