

using apis_dotnet.Models;
using apis_dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace apis_dotnet.Controllers;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareaService _tareaService;

    public TareaController(ITareaService tareaService)
    {
        _tareaService = tareaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var tareas = _tareaService.Get();
        return Ok(tareas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var tarea = await _tareaService.GetById(id);
        if (tarea == null)
        {
            return NotFound();
        }
        return Ok(tarea);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] Tarea tarea)
    {
        await _tareaService.Save(tarea);
        return CreatedAtAction(nameof(Get), new { id = tarea.TareaId }, tarea);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Tarea tarea)
    {
        await _tareaService.Update(id, tarea);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _tareaService.Delete(id);
        return NoContent();
    }
}