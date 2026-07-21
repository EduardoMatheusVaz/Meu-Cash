using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Constantes;
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

        public async Task<Result<DespesaDetalhesViewModel>> ConsultarDespesaPeloId(int id)
        {
            var despesa = await _despesaRepository.ConsultarDespesaPeloId(id: id);

            if (despesa is null)
                return Result<DespesaDetalhesViewModel>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            var despesaViewModel = new DespesaDetalhesViewModel
                (
                    id: despesa.Id,
                    idConta: despesa.IdConta,
                    nomeCategoria: despesa.NomeCategoria,
                    valor: despesa.Valor,
                    dataDespesa: despesa.DataDespesa,
                    descricao: despesa.Descricao
                );

            return Result<DespesaDetalhesViewModel>.Success(despesaViewModel);
        }

        public async Task<Result<List<DespesasViewModel>>> ConsultarDespesasPeloIdConta(int idConta)
        {
            var despesa = await ValidaDespesaExiste(idConta);

            if (!despesa.IsSuccess)
                return Result<List<DespesasViewModel>>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            var despesas = await _despesaRepository.ConsultarDespesasPeloIdConta(id: despesa.Data.Id);

            var despesasViewModel = despesas.Select(x => new DespesasViewModel(
                x.Id,
                x.IdConta,
                x.Valor,
                x.DataDespesa)).ToList();

            return Result<List<DespesasViewModel>>.Success(despesasViewModel);
        }

        public async Task<Result<List<DespesasViewModel>>> ConsultarDespesas()
        {
            var despesas = await _despesaRepository.ConsultarDespesas();

            var despesasViewModel = despesas.Select(x => new DespesasViewModel(
                x.Id,
                x.IdConta,
                x.Valor,
                x.DataDespesa)).ToList();

            return Result<List<DespesasViewModel>>.Success(despesasViewModel);
        }

        public async Task<Result<int>> CriarDespesa(DespesaInputModel despesaInputModel)
        {
            var novaDespesa = new Despesa
                (
                    idConta: despesaInputModel.IdConta, 
                    idCategoria: despesaInputModel.IdCategoria, 
                    valor: despesaInputModel.Valor, 
                    descricao: despesaInputModel.Descricao
                );

            int id = await _despesaRepository.CriarDespesa(novaDespesa);
            return Result<int>.Success(id);
        }

        public async Task<Result> Inativar(int id, string motivoExclusao)
        {
            var despesa = await ValidaDespesaExiste(id: id);

            if (!despesa.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroInativo);

            despesa.Data.Inativar(motivoExclusao: motivoExclusao);
            await _despesaRepository.Inativar();

            return Result.Sucesso();
        }

        public async Task<Result> Atualizar(AtualizarDespesaInputModel atualizarDespesaInputModel)
        {
            var despesa = await ValidaDespesaExiste(id: atualizarDespesaInputModel.Id);

            if (!despesa.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            await _despesaRepository.Atualizar(
                id: atualizarDespesaInputModel.Id,
                idCategoria: atualizarDespesaInputModel.IdCategoria,
                valor: atualizarDespesaInputModel.Valor,
                descricao: atualizarDespesaInputModel.Descricao
            );

            return Result.Sucesso();
        }

        public async Task<Result<List<DespesasViewModel>>> ConsultarDespesasInativadas()
        {
            var despesas = await _despesaRepository.ConsultarDespesasInativadas();

            var despesasViewModel = despesas.Select(x => new DespesasViewModel(
                x.Id,
                x.IdConta,
                x.Valor,
                x.DataDespesa)).ToList();

            return Result<List<DespesasViewModel>>.Success(despesasViewModel);
        }

        public async Task<Result<Despesa>> ValidaDespesaExiste(int id)
        {
            var despesa = await _despesaRepository.ObtemDespesa(id: id);

            if (despesa is null)
                return Result<Despesa>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            return Result<Despesa>.Success(despesa);
        }

        public async Task<Result> Ativar(int id)
        {
            var despesa = await ValidaDespesaExiste(id: id);

            if (despesa.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroAtivo);

            despesa.Data.Ativar();
            await _despesaRepository.Ativar();

            return Result.Sucesso();
        }
    }
}
