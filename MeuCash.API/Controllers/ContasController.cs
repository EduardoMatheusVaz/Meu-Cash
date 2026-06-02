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

        [HttpGet]
        public async Task<IActionResult> ObtemContas()
        {
            var contas = await _contaService.ConsultarContas();

            return Ok(contas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtemContaPeloId(int id)
        {
            var conta = await _contaService.ConsultarContaPeloId(id: id);

            return Ok(conta);
        }

        [HttpPost]
        public async Task<IActionResult> CriarConta(ContaInputModel contaInputModel)
        {
            await _contaService.CriarConta(contaInputModel: contaInputModel);

            return CreatedAtAction(nameof(ObtemContaPeloId), new { Id = contaInputModel });
        }
    }
}
