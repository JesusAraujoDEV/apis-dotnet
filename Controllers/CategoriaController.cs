

using apis_dotnet.Models;
using apis_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace apis_dotnet.Controllers;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        this.categoriaService = categoriaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var categorias = categoriaService.Get();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var categoria = await categoriaService.GetById(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] Categoria categoria)
    {
        await categoriaService.Save(categoria);
        return CreatedAtAction(nameof(Get), new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Categoria categoria)
    {
        await categoriaService.Update(id, categoria);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await categoriaService.Delete(id);
        return NoContent();
    }
}