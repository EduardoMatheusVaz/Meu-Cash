using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task CadastrarUsuario(Usuario usuario);
        Task<List<Usuario>> ConsultarUsuarios();
        Task<Usuario> ConsultarUsuarioPorId(int id);
        Task<Usuario> ConsultarUsuarioPeloNome(string nomeUsuario);
        Task UpdatePeloId(int id, string nome, string username, string senha, string email, string numeroCelular);
        Task DeletePeloId(int id);
    }
}
