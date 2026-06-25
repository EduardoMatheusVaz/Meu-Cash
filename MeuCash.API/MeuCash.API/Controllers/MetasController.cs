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

        [HttpGet()]
        public async Task<IActionResult> ListarMetas()
        {
            var metas = await _metaService.ConsultarMetas();

            return Ok(metas);
        }

        [HttpGet("inativas")]
        public async Task<IActionResult> ListarMetasInativas()
        {
            var metas = await _metaService.ConsultarMetasInativadas();

            return Ok(metas);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ListarMetaPeloId(int id)
        {
            var meta = await _metaService.ConsultarMetaPeloId(id: id);

            return Ok(meta);
        }

        [HttpGet("conta/{id}")]
        public async Task<IActionResult> ListarMetasPeloIdConta(int id)
        {
            var metas = await _metaService.ConsultarMetasPelaConta(idConta: id);

            return Ok(metas);
        }

        [HttpPost()]
        public async Task<IActionResult> CriarMeta([FromBody] MetaInputModel metaInputModel)
        {
            await _metaService.CriarMeta(metaInputModel);

            return CreatedAtAction(nameof(ListarMetaPeloId), new { Id = metaInputModel });
        }

        [HttpPatch("inativar/{id}")]
        public async Task<IActionResult> InativarMeta([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            await _metaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarMeta(int id)
        {
            await _metaService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarMeta([FromBody] AtualizarMetaInputModel atualizarMetaInputModel)
        {
            await _metaService.Atualizar(atualizarMetaInputModel: atualizarMetaInputModel);

            return Ok();
        }
    }
}
