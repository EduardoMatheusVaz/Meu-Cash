using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IMetaService
    {
        Task<Result<int>> CriarMeta(MetaInputModel metaInputModel);
        Task<Result<MetaDetalhesViewModel>> ConsultarMetaPeloId(int id);
        Task<Result<List<MetaViewModel>>> ConsultarMetas();
        Task<Result<List<MetaViewModel>>> ConsultarMetasInativadas();
        Task<Result<List<MetaViewModel>>> ConsultarMetasPelaConta(int idConta);
        Task<Result> Atualizar(AtualizarMetaInputModel atualizarMetaInputModel);
        Task<Result> Inativar(int id, string motivoExclusao);
        Task<Result> Ativar(int id);
        Task<Result<Meta>> ValidaMetaExiste(int id);
    }
}
