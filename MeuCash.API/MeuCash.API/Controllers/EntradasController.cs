using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeuCash.API.Controllers
{
    [ApiController]
    [Route("api/entradas")]
    public class EntradasController : ControllerBase
    {
        private readonly IEntradaService _entradaService;

        public EntradasController(IEntradaService entradaService)
        {
            _entradaService = entradaService;
        }

        [HttpGet()]
        public async Task<IActionResult> ListarEntradas()
        {
            var result = await _entradaService.ConsultarEntradas();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("inativas")]
        public async Task<IActionResult> ListarEntradasInativadas()
        {
            var result = await _entradaService.ConsultarEntradasInativadas();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarEntradaPeloId(int id)
        {
            var result = await _entradaService.ConsultarEntradaPeloId(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("conta/{id}")]
        public async Task<IActionResult> ListarEntradaPelaConta(int id)
        {
            var result = await _entradaService.ConsultarEntradasPeloIdConta(idConta: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CadastrarEntrada([FromBody] EntradaInputModel entradaInputModel)
        {
            var result = await _entradaService.CriarEntrada(entradaInputModel: entradaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(ListarEntradaPeloId), new { Id = result.Data }, result.Data);
        }

        [HttpPatch("{id}/inativar")]
        public async Task<IActionResult> InativarEntrada([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            var result = await _entradaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("{id}/ativar")]
        public async Task<IActionResult> AtivarEntrada(int id)
        {
            var result = await _entradaService.Ativar(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEntrada([FromBody] AtualizarEntradaInputModel atualizarEntradaInputModel)
        {
            var result = await _entradaService.Atualizar(atualizarEntradaInputModel: atualizarEntradaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
