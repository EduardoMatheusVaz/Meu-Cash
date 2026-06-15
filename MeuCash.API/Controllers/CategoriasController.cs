using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.Services.Implementacoes;
using MeuCash.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeuCash.API.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("Obtem-categorias")]
        public async Task<IActionResult> ObtemCategorias()
        {
            var categorias = await _categoriaService.ConsultarCategorias();

            return Ok(categorias);
        }

        [HttpGet("Obtem-categorias-inativadas")]
        public async Task<IActionResult> ObtemCategoriasInativadas()
        {
            var categorias = await _categoriaService.ConsultarCategoriasInativadas();

            return Ok(categorias);
        }

        [HttpGet("Obtem-categoria-pelo-Id/{id}")]
        public async Task<IActionResult> ObtemCategoriaPeloId(int id)
        {
            var categoria = await _categoriaService.ConsultarCategoriaPeloId(id: id);

            return Ok(categoria);
        }

        [HttpPost("Criar-categoria")]
        public async Task<IActionResult> CriarCategoria(CategoriaInputModel categoriaInputModel)
        {
            await _categoriaService.CriarCategoria(categoriaInputModel: categoriaInputModel);

            return CreatedAtAction(nameof(ObtemCategoriaPeloId), new { Id = categoriaInputModel } , categoriaInputModel);
        }

        [HttpPut("Inativar")]
        public async Task<IActionResult> InativarCategoria(InativacaoInputModel inativacaoInputModel)
        {
            await _categoriaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPut("Ativar/{id}")]
        public async Task<IActionResult> AtivarConta(int id)
        {
            await _categoriaService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarCategoria(AtualizarCategoriaInputModel atualizarCategoriaInputModel)
        {
            await _categoriaService.Atualizar(atualizarCategoriaInputModel: atualizarCategoriaInputModel);

            return Ok();
        }
    }
}
