using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeuCash.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("Obtem-cadastrado-pelo-Id/{id}")]
        public async Task<IActionResult> ObtemUsuarioPeloId(int id)
        {
            var usuario = await _usuarioService.ConsultarUsuarioPeloId(id: id);

            return Ok(usuario);
        }

        [HttpGet("Obtem-usuarios")]
        public async Task<IActionResult> ObtemUsuarios()
        {
            var usuarios = await _usuarioService.ConsultarUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("Obtem-usuarios-inativados")]
        public async Task<IActionResult> ObtemUsuariosInativados()
        {
            var usuarios = await _usuarioService.ConsultarUsuariosInativados();

            return Ok(usuarios);
        }

        [HttpGet("Obtem-usuarios-pelo-nome")]
        public async Task<IActionResult> ObtemUsuariosPeloNome([FromQuery] string nome)
        {
            var usuarios = await _usuarioService.ConsultarUsuarioPeloNome(nome: nome); ;

            return Ok(usuarios);
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarUsuario(UsuarioInputModel usuarioInputModel)
        {
            await _usuarioService.CadastrarUsuario(usuarioInputModel: usuarioInputModel);

            return CreatedAtAction(nameof(ObtemUsuarioPeloId), new { Usuario = usuarioInputModel }, usuarioInputModel);
        }

        [HttpPut("Inativar")]
        public async Task<IActionResult> InativarUsuario(InativacaoInputModel inativacaoInputModel)
        {
            await _usuarioService.InativarPeloId(id: inativacaoInputModel.Id, motivo: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPut("Ativar/{id}")]
        public async Task<IActionResult> AtivarUsuario(int id)
        {
            await _usuarioService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarUsuario(AtualizarUsuarioInputModel atualizarUsuarioInputModel)
        {
            await _usuarioService.Atualizar(atualizarUsuarioInputModel: atualizarUsuarioInputModel);

            return Ok();
        }
    }
}
