using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Implementacoes;
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

        [HttpGet("Obtem-despesas")]
        public async Task<IActionResult> ObtemDespesas()
        {
            var despesas = await _despesasService.ConsultarDespesas();

            return Ok(despesas);
        }

        [HttpGet("Obtem-despesas-inativadas")]
        public async Task<IActionResult> ObtemDespesasInativadas()
        {
            var despesas = await _despesasService.ConsultarDespesasInativadas();

            return Ok(despesas);
        }

        [HttpGet("Obtem-despesa-pelo-Id/{id}")]
        public async Task<IActionResult> ObtemDespesaPeloId(int id)
        {
            var despesa = await _despesasService.ConsultarDespesaPeloId(id: id);

            return Ok(despesa);
        }

        [HttpGet("Obtem-despesa-pelo-IdConta/{id}")]
        public async Task<IActionResult> ObtemDespesaPelaConta(int id)
        {
            var despesas = await _despesasService.ConsultarDespesasPeloIdConta(idConta: id);

            return Ok(despesas);
        }

        [HttpPost("Cadastrar-despesa")]
        public async Task<IActionResult> CadastrarDespesa(DespesaInputModel despesaInputModel)
        {
            await _despesasService.CriarDespesa(despesaInputModel: despesaInputModel);

            return CreatedAtAction(nameof(ObtemDespesaPeloId), new { Id = despesaInputModel});
        }

        [HttpPut("Inativar-despesa")]
        public async Task<IActionResult> InativarDespesa(InativacaoInputModel inativacaoInputModel)
        {
            await _despesasService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPut("Ativar/{id}")]
        public async Task<IActionResult> AtivarDespesa(int id)
        {
            await _despesasService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("Atualizar-despesa")]
        public async Task<IActionResult> AtualizarDespesa(AtualizarDespesaInputModel atualizarDespesaInputModel)
        {
            await _despesasService.Atualizar(atualizarDespesaInputModel: atualizarDespesaInputModel);

            return Ok();        
        }

    }
}
