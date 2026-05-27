using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;

namespace MeuCash.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task CadastrarUsuario(Usuario usuario);
        Task<Usuario> ConsultarUsuarioPeloId(int id);
        Task<List<UsuariosDTO>> ConsultarUsuarioPeloNome(string nomeUsuario);
        Task<List<UsuariosDTO>> ConsultarUsuarios();
        Task UpdatePeloId(int id, string nome, string username, string senha, string email, string numeroCelular);
        Task DeletePeloId(int id);
    }
}
