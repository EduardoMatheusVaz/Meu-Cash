using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeuCash.API.Controllers
{
    [ApiController]
    [Route("api/metas")]
    public class MetasController : ControllerBase
    {
        private readonly IMetaService _metaService;

        public MetasController(IMetaService metaService)
        {
            _metaService = metaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtemMetas()
        {
            var metas = await _metaService.ConsultarMetas();

            return Ok(metas);
        }

        [HttpGet("Obtem-Meta-pelo-IdConta/{id}")]
        public async Task<IActionResult> ObtemMetasPeloIdConta(int id)
        {
            var metas = await _metaService.ConsultarMetasPelaConta(idConta: id);

            return Ok(metas);
        }

        [HttpGet("Obtem-Meta-pelo-Id/{id}")]
        public async Task<IActionResult> ObtemMetaPeloId(int id)
        {
            var meta = await _metaService.ConsultarMetaPeloId(id: id);

            return Ok(meta);
        }

        [HttpPost]
        public async Task<IActionResult> CriarMeta(MetaInputModel metaInputModel)
        {
            await _metaService.CriarMeta(metaInputModel);

            return CreatedAtAction(nameof(ObtemMetaPeloId), new { Id = metaInputModel });
        }
    }
}
