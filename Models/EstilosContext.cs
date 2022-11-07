using Microsoft.EntityFrameworkCore;

namespace views_project.Models
{
    public class views_projectContext : DbContext
    {   
        public views_projectContext() : base()
        {
            
        }
        public views_projectContext(DbContextOptions<views_projectContext> opciones) : base(opciones)
        {

        }

        public DbSet<Estilos> Estilos{get; set;}
        public DbSet<Publico> Publico{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) //metodo que está protegido y que no puede ser ingresado
        {
            modelBuilder.Entity<Estilos>(entidad =>{
                entidad.ToTable("Estilos");

                entidad.HasKey(e => e.IDEspecialidad);

                entidad.Property(e => e.Descripcion).IsRequired().HasMaxLength(200).IsUnicode(false); 
            }
            );
        }// Especificar las caracteristicas de nuestros datos para que no sean muy genéricos
    }
}