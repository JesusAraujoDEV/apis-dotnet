using apis_dotnet.Models;

namespace apis_dotnet.Services;

public class TareaService : ITareaService
{
    TareasContext _context;

    public TareaService(TareasContext dbContext)
    {
        _context = dbContext;
    }

    public IEnumerable<Tarea> Get()
    {
        return _context.Tareas.ToList();
    }

    public async Task Save(Tarea tarea)
    {

        //_context.Categorias.Add(categoria);
        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = await _context.Tareas.FindAsync(id);

        if (tareaActual == null)
        {
            throw new Exception("Tarea no encontrada");
        }

        tareaActual.Titulo = tarea.Titulo;
        tareaActual.Descripcion = tarea.Descripcion;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.FechaCreacion = tarea.FechaCreacion;

        await _context.SaveChangesAsync();
    }
    
    public async Task Delete(Guid id)
    {
        var categoriaActual = await _context.Categorias.FindAsync(id);

        if (categoriaActual == null)
        {
            throw new Exception("Categoria no encontrada");
        }

        _context.Categorias.Remove(categoriaActual);
        
        await _context.SaveChangesAsync();
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}