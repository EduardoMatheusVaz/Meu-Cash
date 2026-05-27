using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IMetasRepository
    {
        Task CriarMeta(Meta meta);
        Task<MetaDetalhesDTO> ConsultarMetaPeloId(int id);
        Task<List<MetasDTO>> ConsultarMetas();
        Task<List<MetasDTO>> ConsultarMetasPelaConta(int idConta);
        Task Update(int id, string nome, string descricao, int idUsuario, int idConta, decimal valor, DateTime dataLimite);
        Task Delete(int id);
    }
}
