using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace MeuCash.API.Controllers
{
    [ApiController]
    [Route("api/contas")]
    public class ContasController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContasController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet()]
        public async Task<IActionResult> ListarContas()
        {
            var result = await _contaService.ConsultarContas();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("inativas")]
        public async Task<IActionResult> ListarContasInativas()
        {
            var result = await _contaService.ConsultarContasInativadas();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarContaPeloId(int id)
        {
            var result = await _contaService.ConsultarContaPeloId(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CriarConta([FromBody] ContaInputModel contaInputModel)
        {
            var result = await _contaService.CriarConta(contaInputModel: contaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(ListarContaPeloId), new { Id = result.Data }, result.Data);
        }

        [HttpPatch("inativar/{id}")]
        public async Task<IActionResult> InativarConta([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            var result = await _contaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok();
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarConta(int id)
        {
            var result = await _contaService.Ativar(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualzarContaConta([FromBody] AtualizarContaInputModel atualizarContaInputModel)
        {
            var result = await _contaService.Atualizar(atualizarContaInputModel: atualizarContaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok();
        }
    }
}
