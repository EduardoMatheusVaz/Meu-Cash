using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
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
            var result = await _metaService.ConsultarMetas();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("inativas")]
        public async Task<IActionResult> ListarMetasInativas()
        {
            var result = await _metaService.ConsultarMetasInativadas();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ListarMetaPeloId(int id)
        {
            var result = await _metaService.ConsultarMetaPeloId(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("conta/{id}")]
        public async Task<IActionResult> ListarMetasPeloIdConta(int id)
        {
            var result = await _metaService.ConsultarMetasPelaConta(idConta: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CriarMeta([FromBody] MetaInputModel metaInputModel)
        {
            var result = await _metaService.CriarMeta(metaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(ListarMetaPeloId), new { Id = result.Data }, result.Data);
        }

        [HttpPatch("inativar/{id}")]
        public async Task<IActionResult> InativarMeta([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            var result = await _metaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarMeta(int id)
        {
            var result = await _metaService.Ativar(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarMeta([FromBody] AtualizarMetaInputModel atualizarMetaInputModel)
        {
            var result = await _metaService.Atualizar(atualizarMetaInputModel: atualizarMetaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
