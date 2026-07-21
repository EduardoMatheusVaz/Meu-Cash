using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Result<int>> CadastrarUsuario(UsuarioInputModel usuarioInputModel);
        Task<Result<List<UsuarioViewModel>>> ConsultarUsuarios();
        Task<Result<List<UsuarioViewModel>>> ConsultarUsuariosInativados();
        Task<Result<List<UsuarioViewModel>>> ConsultarUsuarioPeloNome(string nome);
        Task<Result<UsuarioDetalhesViewModel>> ConsultarUsuarioPeloId(int id);
        Task<Result> Atualizar(AtualizarUsuarioInputModel atualizarUsuarioInputModel);
        Task<Result> InativarPeloId(int id, string motivo);
        Task<Result> Ativar(int id);
        Task<Result<Usuario>> ValidaUsuarioExiste(int id);
    }
}
