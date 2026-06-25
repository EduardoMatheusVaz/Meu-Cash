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
            var despesas = await _despesasService.ConsultarDespesasInativadas();

            return Ok(despesas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarDespesaPeloId(int id)
        {
            var despesa = await _despesasService.ConsultarDespesaPeloId(id: id);

            return Ok(despesa);
        }

        [HttpGet("conta/{id}")]
        public async Task<IActionResult> ListarDespesaPelaConta(int id)
        {
            var despesas = await _despesasService.ConsultarDespesasPeloIdConta(idConta: id);

            return Ok(despesas);
        }

        [HttpPost()]
        public async Task<IActionResult> CadastrarDespesa([FromBody] DespesaInputModel despesaInputModel)
        {
            await _despesasService.CriarDespesa(despesaInputModel: despesaInputModel);

            return CreatedAtAction(nameof(ListarDespesaPeloId), new { Id = despesaInputModel});
        }

        [HttpPatch("inativar/{id}")]
        public async Task<IActionResult> InativarDespesa([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            await _despesasService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarDespesa(int id)
        {
            await _despesasService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarDespesa([FromBody] AtualizarDespesaInputModel atualizarDespesaInputModel)
        {
            await _despesasService.Atualizar(atualizarDespesaInputModel: atualizarDespesaInputModel);

            return Ok();        
        }

    }
}
