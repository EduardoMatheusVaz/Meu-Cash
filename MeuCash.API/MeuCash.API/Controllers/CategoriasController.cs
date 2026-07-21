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
            var result = await _categoriaService.ConsultarCategorias();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("inativas")]
        public async Task<IActionResult> ListarCategoriasInativas()
        {
            var result = await _categoriaService.ConsultarCategoriasInativadas();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarCategoriaPeloId(int id)
        {
            var result = await _categoriaService.ConsultarCategoriaPeloId(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CriarCategoria([FromBody] CategoriaInputModel categoriaInputModel)
        {
            var result = await _categoriaService.CriarCategoria(categoriaInputModel: categoriaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(ListarCategoriaPeloId), new { Id = result.Data} , result.Data);
        }

        [HttpPatch("inativar/{id}")]
        public async Task<IActionResult> InativarCategoria([FromBody] InativacaoInputModel inativacaoInputModel)
        {
            var result = await _categoriaService.Inativar(id: inativacaoInputModel.Id, motivoExclusao: inativacaoInputModel.MotivoExclusao);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarConta(int id)
        {
            var result = await _categoriaService.Ativar(id: id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCategoria([FromBody] AtualizarCategoriaInputModel atualizarCategoriaInputModel)
        {
            var result = await _categoriaService.Atualizar(atualizarCategoriaInputModel: atualizarCategoriaInputModel);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
