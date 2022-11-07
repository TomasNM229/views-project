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
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //metodo que está protegido y que no puede ser ingresado
        {
            modelBuilder.Entity<Estilos>(entidad =>{
                entidad.ToTable("Estilos");

                entidad.HasKey(e => e.IDEspecialidad);

                entidad.Property(e => e.Descripcion).IsRequired().HasMaxLength(200).IsUnicode(false); 
            }
            );
            modelBuilder.Entity<Publico>(entidad =>{
                entidad.ToTable("Publico");

                entidad.HasKey(e => e.IDPublico);

                entidad.Property(e => e.Nombre).IsRequired().HasMaxLength(50).IsUnicode(false); 
                entidad.Property(e => e.Apellido).IsRequired().HasMaxLength(50).IsUnicode(false);
                entidad.Property(e => e.Edad).IsRequired().HasMaxLength(10).IsUnicode(false);
                entidad.Property(e => e.Correo).IsRequired().HasMaxLength(100).IsUnicode(false);
                entidad.Property(e => e.Telefono).IsRequired().HasMaxLength(20).IsUnicode(false);
            }
            );
        }// Especificar las caracteristicas de nuestros datos para que no sean muy genéricos

    
    }
}