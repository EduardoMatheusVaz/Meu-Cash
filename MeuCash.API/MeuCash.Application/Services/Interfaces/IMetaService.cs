using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IMetaService
    {
        Task CriarMeta(MetaInputModel metaInputModel);
        Task<MetaDetalhesViewModel> ConsultarMetaPeloId(int id);
        Task<List<MetaViewModel>> ConsultarMetas();
        Task<List<MetaViewModel>> ConsultarMetasInativadas();
        Task<List<MetaViewModel>> ConsultarMetasPelaConta(int idConta);
        Task Atualizar(AtualizarMetaInputModel atualizarMetaInputModel);
        Task Inativar(int id, string motivoExclusao);
        Task Ativar(int id);
        Task<Meta> ValidaMetaExiste(int id);
    }
}
