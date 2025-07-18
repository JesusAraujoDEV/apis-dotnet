using apis_dotnet.Models;

namespace apis_dotnet.Services;

public class CategoriaService : ICategoriaService
{
    TareasContext _context;

    public CategoriaService(TareasContext dbContext)
    {
        _context = dbContext;
    }

    public IEnumerable<Categoria> Get()
    {
        return _context.Categorias.ToList();
    }

    public async Task<Categoria> GetById(Guid id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null)  
        {
            throw new Exception("Categoria no encontrada");
        }
        return categoria;
    }

    public async Task Save(Categoria categoria)
    {

        //_context.Categorias.Add(categoria);
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = await _context.Categorias.FindAsync(id);

        if (categoriaActual == null)
        {
            throw new Exception("Categoria no encontrada");
        }

        categoriaActual.Nombre = categoria.Nombre;
        categoriaActual.Descripcion = categoria.Descripcion;
        categoriaActual.Peso = categoria.Peso;

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

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task<Categoria> GetById(Guid id);
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}