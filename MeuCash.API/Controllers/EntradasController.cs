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

        [HttpGet]
        public async Task<IActionResult> ObtemEntradas()
        {
            var entradas = await _entradaService.ConsultarEntradas();

            return Ok(entradas);
        }

        [HttpGet("{id}/Obtem Entrada pelo Id")]
        public async Task<IActionResult> ObtemEntradaPeloId(int id)
        {
            var entrada = await _entradaService.ConsultarEntradaPeloId(id: id);

            return Ok(entrada);
        }

        [HttpGet("{id}/Obtem Entradas pelo IdConta")]
        public async Task<IActionResult> ObtemEntradaPelaConta(int id)
        {
            var entradas = await _entradaService.ConsultarEntradasPeloIdConta(idConta: id);

            return Ok(entradas);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEntrada(EntradaInputModel entradaInputModel)
        {
            await _entradaService.CriarEntrada(entradaInputModel: entradaInputModel);

            return CreatedAtAction(nameof(ObtemEntradaPeloId), new { Id = entradaInputModel });
        }

    }
}
