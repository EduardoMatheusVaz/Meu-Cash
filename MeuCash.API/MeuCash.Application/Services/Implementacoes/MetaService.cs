using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Constantes;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;

namespace MeuCash.Application.Services.Implementacoes
{
    public class MetaService : IMetaService
    {
        private readonly IMetasRepository _metasRepository;

        public MetaService(IMetasRepository metasRepository)
        {
            _metasRepository = metasRepository;
        }

        public async Task<Result<MetaDetalhesViewModel>> ConsultarMetaPeloId(int id)
        {
            var meta = await ValidaMetaExiste(id: id);

            if (!meta.IsSuccess)
                return Result<MetaDetalhesViewModel>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            var metaViewModel = new MetaDetalhesViewModel
                (
                    id: meta.Data.Id,
                    nome: meta.Data.Nome,
                    descricao: meta.Data.Descricao,
                    idUsuario: meta.Data.IdUsuario,
                    idConta: meta.Data.IdConta,
                    valor: meta.Data.Valor,
                    dataCriacao: meta.Data.DataCriacao,
                    dataLimite: meta.Data.DataLimite
                );

            return Result<MetaDetalhesViewModel>.Success(metaViewModel);
        }

        public async Task<Result<List<MetaViewModel>>> ConsultarMetas()
        {
            var metas = await _metasRepository.ConsultarMetas();

            var metasViewModel = metas.Select(x => new MetaViewModel
            (
                id: x.Id,
                nome: x.Nome,
                idConta: x.IdConta,
                valor: x.Valor
            )).ToList();

            return Result<List<MetaViewModel>>.Success(metasViewModel);
        }

        public async Task<Result<List<MetaViewModel>>> ConsultarMetasPelaConta(int idConta)
        {
            var metas = await _metasRepository.ConsultarMetasPelaConta(idConta: idConta);

            var metasViewModel = metas.Select(x => new MetaViewModel
            (
                id: x.Id,
                nome: x.Nome,
                idConta: x.IdConta,
                valor: x.Valor
            )).ToList();

            return Result<List<MetaViewModel>>.Success(metasViewModel);
        }

        public async Task<Result<int>> CriarMeta(MetaInputModel metaInputModel)
        {
            var novaMeta = new Meta
                (
                    nome: metaInputModel.Nome,
                    descricao: metaInputModel.Descricao,
                    idUsuario: metaInputModel.IdUsuario,
                    idConta: metaInputModel.IdConta,
                    valor: metaInputModel.Valor,
                    dataLimite: metaInputModel.DataLimite
                );

            int id = await _metasRepository.CriarMeta(meta: novaMeta);
            return Result<int>.Success(id);
        }

        public async Task<Result> Inativar(int id, string motivoExclusao)
        {
            var meta = await _metasRepository.ConsultarMetaExiste(id: id);

            if (!meta.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            meta.Inativar(motivoExclusao: motivoExclusao);
            await _metasRepository.Inativar();

            return Result.Sucesso();
        }

        public async Task<Result> Atualizar(AtualizarMetaInputModel atualizarMetaInputModel)
        {
            var meta = await ValidaMetaExiste(atualizarMetaInputModel.Id);

            if (!meta.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            await _metasRepository.Atualizar(
                id: atualizarMetaInputModel.Id,
                nome: atualizarMetaInputModel.Nome,
                descricao: atualizarMetaInputModel.Descricao,
                valor: atualizarMetaInputModel.Valor,
                dataLimite: atualizarMetaInputModel.DataLimite);

            return Result.Sucesso();
        }

        public async Task<Result<List<MetaViewModel>>> ConsultarMetasInativadas()
        {
            var metas = await _metasRepository.ConsultarMetasInativadas();

            var metasViewModel = metas.Select(x => new MetaViewModel
            (
                id: x.Id,
                nome: x.Nome,
                idConta: x.IdConta,
                valor: x.Valor
            )).ToList();

            return Result<List<MetaViewModel>>.Success(metasViewModel);
        }

        public async Task<Result<Meta>> ValidaMetaExiste(int id)
        {
            var meta = await _metasRepository.ConsultarMetaExiste(id: id);

            if (meta is null)
                return Result<Meta>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            return Result<Meta>.Success(meta);
        }

        public async Task<Result> Ativar(int id)
        {
            var meta = await ValidaMetaExiste(id: id);

            if (!meta.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            if (meta.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroAtivo);

            meta.Data.Ativar();
            await _metasRepository.Ativar(meta.Data);

            return Result.Sucesso();
        }
    }
}
