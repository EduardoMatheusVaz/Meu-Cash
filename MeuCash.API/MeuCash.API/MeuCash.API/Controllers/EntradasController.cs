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
            var entradas = await _entradaService.ConsultarEntradas();

            return Ok(entradas);
        }

        [HttpGet("inativas")]
        public async Task<IActionResult> ListarEntradasInativadas()
        {
            var entradas = await _entradaService.ConsultarEntradasInativadas();

            return Ok(entradas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarEntradaPeloId(int id)
        {
            var entrada = await _entradaService.ConsultarEntradaPeloId(id: id);

            return Ok(entrada);
        }

        [HttpGet("conta/{id}")]
        public async Task<IActionResult> ListarEntradaPelaConta(int id)
        {
            var entradas = await _entradaService.ConsultarEntradasPeloIdConta(idConta: id);

            return Ok(entradas);
        }

        [HttpPost()]
        public async Task<IActionResult> CadastrarEntrada([FromBody] EntradaInputModel entradaInputModel)
        {
            await _entradaService.CriarEntrada(entradaInputModel: entradaInputModel);

            return CreatedAtAction(nameof(ListarEntradaPeloId), new { Id = entradaInputModel });
        }

        [HttpPatch("{id}/inativar")]
        public async Task<IActionResult> InativarEntrada([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            await _entradaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPatch("{id}/ativar")]
        public async Task<IActionResult> AtivarEntrada(int id)
        {
            await _entradaService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEntrada([FromBody] AtualizarEntradaInputModel atualizarEntradaInputModel)
        {
            await _entradaService.Atualizar(atualizarEntradaInputModel: atualizarEntradaInputModel);

            return Ok();
        }
    }
}
