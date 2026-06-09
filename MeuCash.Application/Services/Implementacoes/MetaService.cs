using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;
using System.Drawing;

namespace MeuCash.Application.Services.Implementacoes
{
    public class MetaService : IMetaService
    {
        private readonly IMetasRepository _metasRepository;

        public MetaService(IMetasRepository metasRepository)
        {
            _metasRepository = metasRepository;
        }

        public async Task<MetaDetalhesViewModel> ConsultarMetaPeloId(int id)
        {
            var meta = await _metasRepository.ConsultarMetaPeloId(id: id);

            var metaViewModel = new MetaDetalhesViewModel
                (
                    id: meta.Id,
                    nome: meta.Nome,
                    descricao: meta.Descricao,
                    idUsuario: meta.IdUsuario,
                    idConta: meta.IdConta,
                    valor: meta.Valor,
                    dataCriacao: meta.DataCriacao,
                    dataLimite: meta.DataLimite
                );

            return metaViewModel;
        }

        public async Task<List<MetaViewModel>> ConsultarMetas()
        {
            var metas = await _metasRepository.ConsultarMetas();

            var metasViewModel = metas.Select(x => new MetaViewModel
            (
                id: x.Id,
                nome: x.Nome,
                idConta: x.IdConta,
                valor: x.Valor
            )).ToList();

            return metasViewModel;
        }

        public async Task<List<MetaViewModel>> ConsultarMetasPelaConta(int idConta)
        {
            var metas = await _metasRepository.ConsultarMetasPelaConta(idConta: idConta);

            var metasViewModel = metas.Select(x => new MetaViewModel
            (
                id: x.Id,
                nome: x.Nome,
                idConta: x.IdConta,
                valor: x.Valor
            )).ToList();

            return metasViewModel;
        }

        public async Task CriarMeta(MetaInputModel metaInputModel)
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

            await _metasRepository.CriarMeta(meta: novaMeta);
        }

        public async Task Inativar(int id, string motivoExclusao)
        {
            await _metasRepository.Inativar(id: id, motivoExclusao:  motivoExclusao);
        }

        public async Task Atualizar(AtualizarMetaInputModel atualizarMetaInputModel)
        {
            await _metasRepository.Atualizar(
                id: atualizarMetaInputModel.Id,
                nome: atualizarMetaInputModel.Nome,
                descricao: atualizarMetaInputModel.Descricao,
                valor: atualizarMetaInputModel.Valor,
                dataLimite: atualizarMetaInputModel.DataLimite);
        }

        public async Task<List<MetaViewModel>> ConsultarMetasInativadas()
        {
            var metas = await _metasRepository.ConsultarMetasInativadas();

            var metasViewModel = metas.Select(x => new MetaViewModel
            (
                id: x.Id,
                nome: x.Nome,
                idConta: x.IdConta,
                valor: x.Valor
            )).ToList();

            return metasViewModel;
        }
    }
}
