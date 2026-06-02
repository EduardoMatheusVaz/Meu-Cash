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

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtemUsuarioPeloId(int id)
        {
            var usuario = await _usuarioService.ConsultarUsuarioPeloId(id: id);

            return Ok(usuario);
        }

        [HttpGet("Obtem Usuários")]
        public async Task<IActionResult> ObtemUsuarios()
        {
            var usuarios = await _usuarioService.ConsultarUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("Obtem Usuários pelo nome")]
        public async Task<IActionResult> ObtemUsuariosPeloNome([FromQuery] string nome)
        {
            var usuarios = await _usuarioService.ConsultarUsuarioPeloNome(nome: nome); ;

            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(UsuarioInputModel usuarioInputModel)
        {
            await _usuarioService.CadastrarUsuario(usuarioInputModel: usuarioInputModel);

            return CreatedAtAction(nameof(ObtemUsuarioPeloId), new { Usuario = usuarioInputModel }, usuarioInputModel);
        }
    }
}
