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

        [HttpGet]
        public async Task<IActionResult> ObtemCategorias()
        {
            var categorias = await _categoriaService.ConsultarCategorias();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtemCategoriaPeloId(int id)
        {
            var categoria = await _categoriaService.ConsultarCategoriaPeloId(id: id);

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCategoria(CategoriaInputModel categoriaInputModel)
        {
            await _categoriaService.CriarCategoria(categoriaInputModel: categoriaInputModel);

            return CreatedAtAction(nameof(ObtemCategoriaPeloId), new { Usuario = categoriaInputModel });
        }
    }
}
