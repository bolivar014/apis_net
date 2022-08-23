using webapi.Models;

// importamos la carpeta Services en la raiz del proyecto
namespace webapi.Services;

public class TareasService : ITareasService{
    TareasContext context;
    // 
    public TareasService(TareasContext dbcontext) {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get() {
        return context.Tareas;
    }

    // Generamos la creación de una nueva tarea
    public async Task Save(Tarea tarea) {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }
    // Generamos la actualización de una Tarea
    public async Task Update(Guid id, Tarea tarea) {
        var tareaActual = context.Tareas.Find(id);

        if(tareaActual != null) {
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.Resumen = tarea.Resumen;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;

            await context.SaveChangesAsync();
        }
    }
    // Generamos la Eliminación de una Tarea
    public async Task Delete(Guid id) {
        var tareaActual = context.Tareas.Find(id);

        if(tareaActual != null) {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareasService {
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}