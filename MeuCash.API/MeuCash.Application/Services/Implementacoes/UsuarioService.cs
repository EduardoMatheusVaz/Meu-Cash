using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Constantes;
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

        public async Task<Result> Ativar(int id)
        {
            var usuario = await ValidaUsuarioExiste(id: id);

            if (!usuario.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            if (usuario.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroAtivo);

            usuario.Data.Ativar();
            await _usuarioRepository.Ativar(usuario: usuario.Data);

            return Result.Sucesso();
        }

        public async Task<Result> Atualizar(AtualizarUsuarioInputModel atualizarUsuarioInputModel)
        {
            var usuario = await ValidaUsuarioExiste(id: atualizarUsuarioInputModel.Id);

            if (!usuario.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            if (!usuario.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroInativo);

            await _usuarioRepository.Atualizar(
                id: atualizarUsuarioInputModel.Id,
                nome: atualizarUsuarioInputModel.Nome,
                userName: atualizarUsuarioInputModel.UserName,
                senha: atualizarUsuarioInputModel.Senha,
                email: atualizarUsuarioInputModel.Email,
                numeroCelular: atualizarUsuarioInputModel.NumeroCelular);

            return Result.Sucesso();
        }

        public async Task<Result<int>> CadastrarUsuario(UsuarioInputModel usuarioInputModel)
        {
            var novoUsuario = new Usuario(
                nome: usuarioInputModel.Nome,
                userName: usuarioInputModel.UserName,
                senha: usuarioInputModel.Senha,
                email: usuarioInputModel.Email,
                numeroCelular: usuarioInputModel.NumeroCelular
            );

            int id = await _usuarioRepository.CadastrarUsuario(usuario: novoUsuario);
            return Result<int>.Success(id);
        }

        public async Task<Result<UsuarioDetalhesViewModel>> ConsultarUsuarioPeloId(int id)
        {
            var usuario = await ValidaUsuarioExiste(id: id);

            if (!usuario.IsSuccess)
                return Result<UsuarioDetalhesViewModel>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            var usuarioViewModel = new UsuarioDetalhesViewModel
                (
                    id: usuario.Data.Id,
                    nome: usuario.Data.Nome,
                    userName: usuario.Data.UserName,
                    senha: usuario.Data.Senha,
                    email: usuario.Data.Email,
                    numeroCelular: usuario.Data.NumeroCelular
                );

            return Result<UsuarioDetalhesViewModel>.Success(usuarioViewModel);
        }

        public async Task<Result<List<UsuarioViewModel>>> ConsultarUsuarioPeloNome(string nome)
        {
            var usuarios = await _usuarioRepository.ConsultarUsuarioPeloNome(nomeUsuario: nome);

            var usuariosViewModel = usuarios.Select(x => new UsuarioViewModel
            (
                id: x.Id,
                nome: x.Nome,
                email: x.Email,
                numeroCelular: x.NumeroCelular
            )).ToList();

            return Result<List<UsuarioViewModel>>.Success(usuariosViewModel);
        }

        public async Task<Result<List<UsuarioViewModel>>> ConsultarUsuarios()
        {
            var usuarios = await _usuarioRepository.ConsultarUsuarios();

            var usuariosViewModel = usuarios.Select(x => new UsuarioViewModel
            (
                id: x.Id,
                nome: x.Nome,
                email: x.Email,
                numeroCelular: x.NumeroCelular)
            ).ToList();
            
            return Result<List<UsuarioViewModel>>.Success(usuariosViewModel);
        }

        public async Task<Result<List<UsuarioViewModel>>> ConsultarUsuariosInativados()
        {
            var usuarios = await _usuarioRepository.ConsultarUsuariosInativados();

            var usuariosViewModel = usuarios.Select(x => new UsuarioViewModel
            (
                id: x.Id,
                nome: x.Nome,
                email: x.Email,
                numeroCelular: x.NumeroCelular)
            ).ToList();

            return Result<List<UsuarioViewModel>>.Success(usuariosViewModel); ;
        }

        public async Task<Result> InativarPeloId(int id, string motivo)
        {
            var usuario = await ValidaUsuarioExiste(id: id);

            if (!usuario.IsSuccess)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            if (!usuario.Data.Ativo)
                return Result.Erro(GenericConstantes.ErrorMessages.RegistroInativo);

            usuario.Data.Inativar(motivoExclusao: motivo);
            await _usuarioRepository.Inativar();

            return Result.Sucesso();
        }

        public async Task<Result<Usuario>> ValidaUsuarioExiste(int id)
        {
            var usuario = await _usuarioRepository.ConsultarUsuarioPeloId(id: id);

            if (usuario is null)
                return Result<Usuario>.Error(GenericConstantes.ErrorMessages.RegistroNaoEncontrado);

            return Result<Usuario>.Success(usuario);
        }
    }
}
