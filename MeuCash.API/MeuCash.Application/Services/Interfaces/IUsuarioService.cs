using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Core.Entidades;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task CadastrarUsuario(UsuarioInputModel usuarioInputModel);
        Task<List<UsuarioViewModel>> ConsultarUsuarios();
        Task<List<UsuarioViewModel>> ConsultarUsuariosInativados();
        Task<List<UsuarioViewModel>> ConsultarUsuarioPeloNome(string nome);
        Task<UsuarioDetalhesViewModel> ConsultarUsuarioPeloId(int id);
        Task Atualizar(AtualizarUsuarioInputModel atualizarUsuarioInputModel);
        Task InativarPeloId(int id, string motivo);
        Task Ativar(int id);
        Task<Usuario> ValidaUsuarioExiste(int id);
    }
}
