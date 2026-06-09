using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;

namespace MeuCash.Application.Services.Implementacoes
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Atualizar(AtualizarUsuarioInputModel atualizarUsuarioInputModel)
        {
            await _usuarioRepository.Atualizar(
                id: atualizarUsuarioInputModel.Id,
                nome: atualizarUsuarioInputModel.Nome,
                userName: atualizarUsuarioInputModel.UserName,
                senha: atualizarUsuarioInputModel.Senha,
                email: atualizarUsuarioInputModel.Email,
                numeroCelular: atualizarUsuarioInputModel.NumeroCelular);
        }

        public async Task CadastrarUsuario(UsuarioInputModel usuarioInputModel)
        {
            var novoUsuario = new Usuario(
                nome: usuarioInputModel.Nome,
                userName: usuarioInputModel.UserName,
                senha: usuarioInputModel.Senha,
                email: usuarioInputModel.Email,
                numeroCelular: usuarioInputModel.NumeroCelular
            );

            await _usuarioRepository.CadastrarUsuario(usuario: novoUsuario);
        }

        public async Task<UsuarioDetalhesViewModel> ConsultarUsuarioPeloId(int id)
        {
            var usuario = await _usuarioRepository.ConsultarUsuarioPeloId(id: id);

            var usuarioViewModel = new UsuarioDetalhesViewModel
                (
                    id: usuario.Id,
                    nome: usuario.Nome,
                    userName: usuario.UserName,
                    senha: usuario.Senha,
                    email: usuario.Email,
                    numeroCelular: usuario.NumeroCelular
                );

            return usuarioViewModel;
        }

        public async Task<List<UsuarioViewModel>> ConsultarUsuarioPeloNome(string nome)
        {
            var usuarios = await _usuarioRepository.ConsultarUsuarioPeloNome(nomeUsuario: nome);

            var usuariosViewModel = usuarios.Select(x => new UsuarioViewModel
            (
                id: x.Id,
                nome: x.Nome,
                email: x.Email,
                numeroCelular: x.NumeroCelular
            )).ToList();

            return usuariosViewModel;
        }

        public async Task<List<UsuarioViewModel>> ConsultarUsuarios()
        {
            var usuarios = await _usuarioRepository.ConsultarUsuarios();

            var usuariosViewModel = usuarios.Select(x => new UsuarioViewModel
            (
                id: x.Id,
                nome: x.Nome,
                email: x.Email,
                numeroCelular: x.NumeroCelular)
            ).ToList();
            
            return usuariosViewModel;
        }

        public async Task<List<UsuarioViewModel>> ConsultarUsuariosInativados()
        {
            var usuarios = await _usuarioRepository.ConsultarUsuariosInativados();

            var usuariosViewModel = usuarios.Select(x => new UsuarioViewModel
            (
                id: x.Id,
                nome: x.Nome,
                email: x.Email,
                numeroCelular: x.NumeroCelular)
            ).ToList();

            return usuariosViewModel; ;
        }

        public async Task InativarPeloId(int id, string motivo)
        {
            await _usuarioRepository.InativarPeloId(id: id, motivoExclusao: motivo);
        }
    }
}
