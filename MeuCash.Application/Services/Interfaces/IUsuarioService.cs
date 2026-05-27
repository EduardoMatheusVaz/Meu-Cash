using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;

namespace MeuCash.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task CadastrarUsuario(UsuarioInputModel usuarioInputModel);
        Task<List<UsuarioViewModel>> ConsultarUsuarios();
        Task<List<UsuarioViewModel>> ConsultarUsuarioPeloNome(string nome);
        Task<UsuarioDetalhesViewModel> ConsultarUsuarioPeloId(int id);
        //Task AtualizarPeloId(int id);
        //Task DeletarPeloId(int id);

    }
}
