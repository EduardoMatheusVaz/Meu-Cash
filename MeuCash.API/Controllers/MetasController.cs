using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Implementacoes;
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

        [HttpGet("Obtem-metas")]
        public async Task<IActionResult> ObtemMetas()
        {
            var metas = await _metaService.ConsultarMetas();

            return Ok(metas);
        }

        [HttpGet("Obtem-metas-inativadas")]
        public async Task<IActionResult> ObtemMetasInativadas()
        {
            var metas = await _metaService.ConsultarMetasInativadas();

            return Ok(metas);
        }

        [HttpGet("Obtem-meta-pelo-IdConta/{id}")]
        public async Task<IActionResult> ObtemMetasPeloIdConta(int id)
        {
            var metas = await _metaService.ConsultarMetasPelaConta(idConta: id);

            return Ok(metas);
        }

        [HttpGet("Obtem-meta-pelo-Id/{id}")]
        public async Task<IActionResult> ObtemMetaPeloId(int id)
        {
            var meta = await _metaService.ConsultarMetaPeloId(id: id);

            return Ok(meta);
        }

        [HttpPost("Criar-meta")]
        public async Task<IActionResult> CriarMeta(MetaInputModel metaInputModel)
        {
            await _metaService.CriarMeta(metaInputModel);

            return CreatedAtAction(nameof(ObtemMetaPeloId), new { Id = metaInputModel });
        }

        [HttpPut("Inativar-meta")]
        public async Task<IActionResult> InativarMeta(InativacaoInputModel inativacaoInputModel)
        {
            await _metaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPut("Ativar/{id}")]
        public async Task<IActionResult> AtivarMeta(int id)
        {
            await _metaService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("Atualizar-meta")]
        public async Task<IActionResult> AtualizarMeta(AtualizarMetaInputModel atualizarMetaInputModel)
        {
            await _metaService.Atualizar(atualizarMetaInputModel: atualizarMetaInputModel);

            return Ok();
        }
    }
}
