using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IMetasRepository
    {
        Task CriarMeta(Meta meta);
        Task<Meta> ConsultarMetaPeloId(int id);
        Task<List<Meta>> ConsultarMetas();
        Task<List<Meta>> ConsultarMetasPelaConta(int idConta);
        Task Update(int id, string nome, string descricao, int idUsuario, int idConta, decimal valor, DateTime dataLimite);
        Task Delete(int id);
    }
}
