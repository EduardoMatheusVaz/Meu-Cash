using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Interfaces;
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

        [HttpGet("Obtem-contas")]
        public async Task<IActionResult> ObtemContas()
        {
            var contas = await _contaService.ConsultarContas();

            return Ok(contas);
        }

        [HttpGet("Obtem-contas-inativadas")]
        public async Task<IActionResult> ObtemContasInativadas()
        {
            var contas = await _contaService.ConsultarContasInativadas();

            return Ok(contas);
        }

        [HttpGet("Obtem-conta-pelo-Id/{id}")]
        public async Task<IActionResult> ObtemContaPeloId(int id)
        {
            var conta = await _contaService.ConsultarContaPeloId(id: id);

            return Ok(conta);
        }

        [HttpPost("Criar-conta")]
        public async Task<IActionResult> CriarConta(ContaInputModel contaInputModel)
        {
            await _contaService.CriarConta(contaInputModel: contaInputModel);

            return CreatedAtAction(nameof(ObtemContaPeloId), new { Id = contaInputModel });
        }

        [HttpPut("Inativar-conta")]
        public async Task<IActionResult> InativarConta(InativacaoInputModel inativacaoInputModel)
        {
            await _contaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPut("Atualizar-conta")]
        public async Task<IActionResult> AtualzarContaConta(AtualizarContaInputModel atualizarContaInputModel)
        {
            await _contaService.Atualizar(atualizarContaInputModel: atualizarContaInputModel);

            return Ok();
        }
    }
}
