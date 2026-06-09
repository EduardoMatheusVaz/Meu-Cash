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

        [HttpGet("Obtem-entradas")]
        public async Task<IActionResult> ObtemEntradas()
        {
            var entradas = await _entradaService.ConsultarEntradas();

            return Ok(entradas);
        }

        [HttpGet("Obtem-entradas-inativadas")]
        public async Task<IActionResult> ObtemEntradasInativadas()
        {
            var entradas = await _entradaService.ConsultarEntradasInativadas();

            return Ok(entradas);
        }

        [HttpGet("Obtem-entrada-pelo-Id/{id}")]
        public async Task<IActionResult> ObtemEntradaPeloId(int id)
        {
            var entrada = await _entradaService.ConsultarEntradaPeloId(id: id);

            return Ok(entrada);
        }

        [HttpGet("Obtem-entradas-pelo-IdConta/{id}")]
        public async Task<IActionResult> ObtemEntradaPelaConta(int id)
        {
            var entradas = await _entradaService.ConsultarEntradasPeloIdConta(idConta: id);

            return Ok(entradas);
        }

        [HttpPost("Cadastrar-entrada")]
        public async Task<IActionResult> CadastrarEntrada(EntradaInputModel entradaInputModel)
        {
            await _entradaService.CriarEntrada(entradaInputModel: entradaInputModel);

            return CreatedAtAction(nameof(ObtemEntradaPeloId), new { Id = entradaInputModel });
        }

        [HttpPut("Inativar-entrada")]
        public async Task<IActionResult> InativarEntrada(InativacaoInputModel inativacaoInputModel)
        {
            await _entradaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPut("Atualizar-entrada")]
        public async Task<IActionResult> AtualizarEntrada(AtualizarEntradaInputModel atualizarEntradaInputModel)
        {
            await _entradaService.Atualizar(atualizarEntradaInputModel: atualizarEntradaInputModel);

            return Ok();
        }
    }
}
