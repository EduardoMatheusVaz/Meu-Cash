using MeuCash.Application.DTOs.Input_Models;
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

        [HttpGet()]
        public async Task<IActionResult> ListarCategorias()
        {
            var categorias = await _categoriaService.ConsultarCategorias();

            return Ok(categorias);
        }

        [HttpGet("inativas")]
        public async Task<IActionResult> ListarCategoriasInativas()
        {
            var categorias = await _categoriaService.ConsultarCategoriasInativadas();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarCategoriaPeloId(int id)
        {
            var categoria = await _categoriaService.ConsultarCategoriaPeloId(id: id);

            return Ok(categoria);
        }

        [HttpPost()]
        public async Task<IActionResult> CriarCategoria([FromBody] CategoriaInputModel categoriaInputModel)
        {
            await _categoriaService.CriarCategoria(categoriaInputModel: categoriaInputModel);

            return CreatedAtAction(nameof(ListarCategoriaPeloId), new { Id = categoriaInputModel } , categoriaInputModel);
        }

        [HttpPatch("inativar/{id}")]
        public async Task<IActionResult> InativarCategoria([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            await _categoriaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);

            return Ok();
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarConta(int id)
        {
            await _categoriaService.Ativar(id: id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCategoria([FromBody] AtualizarCategoriaInputModel atualizarCategoriaInputModel)
        {
            await _categoriaService.Atualizar(atualizarCategoriaInputModel: atualizarCategoriaInputModel);

            return Ok();
        }
    }
}
