using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeuCash.API.Controllers
{
    [ApiController]
    [Route("api/despesas")]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesaService _despesasService;

        public DespesasController(IDespesaService despesasService)
        {
            _despesasService = despesasService;
        }

        [HttpGet()]
        public async Task<IActionResult> ListarDespesas()
        {
            var despesas = await _despesasService.ConsultarDespesas();

            return Ok(despesas);
        }

        [HttpGet("inativas")]
        public async Task<IActionResult> ListarDespesasInativas()
        {
            var result = await _despesasService.ConsultarDespesasInativadas();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarDespesaPeloId(int id)
        {
            var result = await _despesasService.ConsultarDespesaPeloId(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("conta/{id}")]
        public async Task<IActionResult> ListarDespesaPelaConta(int id)
        {
            var result = await _despesasService.ConsultarDespesasPeloIdConta(idConta: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CadastrarDespesa([FromBody] DespesaInputModel despesaInputModel)
        {
            var result = await _despesasService.CriarDespesa(despesaInputModel: despesaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(ListarDespesaPeloId), new { Id = result.Data }, result.Data);
        }

        [HttpPatch("inativar/{id}")]
        public async Task<IActionResult> InativarDespesa([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            var result = await _despesasService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarDespesa(int id)
        {
            var result = await _despesasService.Ativar(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarDespesa([FromBody] AtualizarDespesaInputModel atualizarDespesaInputModel)
        {
            var result = await _despesasService.Atualizar(atualizarDespesaInputModel: atualizarDespesaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);        
        }

    }
}
