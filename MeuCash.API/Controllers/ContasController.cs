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

        [HttpGet()]
        public async Task<IActionResult> ListarContas()
        {
            var contas = await _contaService.ConsultarContas();

            return Ok(contas);
        }

        [HttpGet("inativas")]
        public async Task<IActionResult> ListarContasInativas()
        {
            var contas = await _contaService.ConsultarContasInativadas();

            return Ok(contas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarContaPeloId(int id)
        {
            var conta = await _contaService.ConsultarContaPeloId(id: id);

            return Ok(conta);
        }

        [HttpPost()]
        public async Task<IActionResult> CriarConta([FromBody] ContaInputModel contaInputModel)
        {
            await _contaService.CriarConta(contaInputModel: contaInputModel);

            return CreatedAtAction(nameof(ListarContaPeloId), new { Id = contaInputModel });
        }

        [HttpPatch("inativar/{id}")]
        public async Task<IActionResult> InativarConta([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            await _contaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarConta(int id)
        {
            await _contaService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualzarContaConta([FromBody] AtualizarContaInputModel atualizarContaInputModel)
        {
            await _contaService.Atualizar(atualizarContaInputModel: atualizarContaInputModel);

            return Ok();
        }
    }
}
