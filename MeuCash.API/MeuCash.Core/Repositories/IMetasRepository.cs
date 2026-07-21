using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IMetasRepository
    {
        Task<int> CriarMeta(Meta meta);
        Task<MetaDetalhesDTO> ConsultarMetaPeloId(int id);
        Task<List<MetasDTO>> ConsultarMetas();
        Task<List<MetasDTO>> ConsultarMetasInativadas();
        Task<List<MetasDTO>> ConsultarMetasPelaConta(int idConta);
        Task Atualizar(int id, string nome, string descricao, decimal valor, DateTime dataLimite);
        Task Inativar();
        Task Ativar(Meta meta);
        Task<Meta> ConsultarMetaExiste(int id);
    }
}
