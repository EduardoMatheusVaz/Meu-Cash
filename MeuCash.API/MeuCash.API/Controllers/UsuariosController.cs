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
            var result = await _usuarioService.ConsultarUsuarios();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("inativos")]
        public async Task<IActionResult> ListarUsuariosInativados()
        {
            var result = await _usuarioService.ConsultarUsuariosInativados();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("nome")]
        public async Task<IActionResult> ListarUsuariosPeloNome([FromQuery] string nome)
        {
            var result = await _usuarioService.ConsultarUsuarioPeloNome(nome: nome); ;

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarUsuarioPeloId(int id)
        {
            var result = await _usuarioService.ConsultarUsuarioPeloId(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioInputModel usuarioInputModel)
        {
            var result = await _usuarioService.CadastrarUsuario(usuarioInputModel: usuarioInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(ListarUsuarioPeloId), new { Id = result.Data }, result.Data);
        }

        [HttpPatch("{id}/inativar")]
        public async Task<IActionResult> InativarUsuario([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            var result = await _usuarioService.InativarPeloId(id: inativacaoInputModel.Id, motivo: inativacaoInputModel.MotivoExclusao);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("{id}/ativar")]
        public async Task<IActionResult> AtivarUsuario(int id)
        {
            var result = await _usuarioService.Ativar(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] AtualizarUsuarioInputModel atualizarUsuarioInputModel)
        {
            var result = await _usuarioService.Atualizar(atualizarUsuarioInputModel: atualizarUsuarioInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
