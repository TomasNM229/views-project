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
    }
}