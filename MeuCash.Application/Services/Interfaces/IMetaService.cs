using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IMetaService
    {
        Task CriarMeta(MetaInputModel metaInputModel);
        Task<MetaDetalhesViewModel> ConsultarMetaPeloId(int id);
        Task<List<MetaViewModel>> ConsultarMetas();
        Task<List<MetaViewModel>> ConsultarMetasPelaConta(int idConta);
        //Task Update(int id, string nome, string descricao, int idUsuario, int idConta, decimal valor, DateTime dataLimite);
        //Task Delete(int id);
    }
}
