using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class TareasContext : DbContext {
    // Declaramos cada colección ó tabla que vamos a utilizar
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    // Metodo de entity Framework
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        List<Categoria> categoriasInit = new List<Categoria>();
        // 
        categoriasInit.Add(new Categoria() {
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb"), 
            Nombre = "Actividades Pendientes", 
            Peso = 20
        });
        categoriasInit.Add(new Categoria() {
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dasf"), 
            Nombre = "Actividades Personales", 
            Peso = 10
        });

        modelBuilder.Entity<Categoria>(categoria => {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() {
            TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540123"),
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb"),
            PrioridadTarea = Prioridad.Alta,
            Titulo = "Pago de servicios",
            FechaCreacion = DateTime.Now,
        });
        tareasInit.Add(new Tarea() {
            TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540123"),
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dasf"),
            PrioridadTarea = Prioridad.Baja,
            Titulo = "Ver pelicula",
            FechaCreacion = DateTime.Now,
        });

        modelBuilder.Entity<Tarea>(tarea => {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
            tarea.HasData(tareasInit);
        });
    }
}
