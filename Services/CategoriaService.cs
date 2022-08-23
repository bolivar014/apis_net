using webapi.Models;

// importamos la carpeta Services en la raiz del proyecto
namespace webapi.Services;

public class CategoriaService : ICategoriaService {
    TareasContext context;
    // 
    public CategoriaService(TareasContext dbcontext) {
        context = dbcontext;
    }
    // 
    public IEnumerable<Categoria> Get() {
        return context.Categorias;
    }

    // Generamos la creación de una nueva categoria
    public async Task Save(Categoria categoria) {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }
    // Generamos la actualización de una categoria
    public async Task Update(Guid id, Categoria categoria) {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual != null) {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }
    }
    // Generamos la Eliminación de una categoria
    public async Task Delete(Guid id) {
        // Generamos busqueda del registro en la tabla categorias
        var categoriaActual = context.Categorias.Find(id);

        // En caso que exista el ID, se posee a eliminar
        if(categoriaActual != null) {
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }
}

// Creando los servicios
public interface ICategoriaService {
    IEnumerable<Categoria> Get();

    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}