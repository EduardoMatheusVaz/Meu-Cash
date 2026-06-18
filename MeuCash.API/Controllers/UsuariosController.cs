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

        [HttpGet()]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _usuarioService.ConsultarUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("inativos")]
        public async Task<IActionResult> ListarUsuariosInativados()
        {
            var usuarios = await _usuarioService.ConsultarUsuariosInativados();

            return Ok(usuarios);
        }

        [HttpGet("nome")]
        public async Task<IActionResult> ListarUsuariosPeloNome([FromQuery] string nome)
        {
            var usuarios = await _usuarioService.ConsultarUsuarioPeloNome(nome: nome); ;

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarUsuarioPeloId(int id)
        {
            var usuario = await _usuarioService.ConsultarUsuarioPeloId(id: id);

            return Ok(usuario);
        }

        [HttpPost()]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioInputModel usuarioInputModel)
        {
            await _usuarioService.CadastrarUsuario(usuarioInputModel: usuarioInputModel);

            return CreatedAtAction(nameof(ListarUsuarioPeloId), new { Usuario = usuarioInputModel }, usuarioInputModel);
        }

        [HttpPatch("{id}/inativar")]
        public async Task<IActionResult> InativarUsuario([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            await _usuarioService.InativarPeloId(id: inativacaoInputModel.Id, motivo: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPatch("{id}/ativar")]
        public async Task<IActionResult> AtivarUsuario(int id)
        {
            await _usuarioService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] AtualizarUsuarioInputModel atualizarUsuarioInputModel)
        {
            await _usuarioService.Atualizar(atualizarUsuarioInputModel: atualizarUsuarioInputModel);

            return Ok();
        }
    }
}
