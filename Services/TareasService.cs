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
}

public interface ITareasService {
    IEnumerable<Tarea> Get();
}