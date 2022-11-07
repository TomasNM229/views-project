using System.ComponentModel.DataAnnotations;

namespace views_project.Models
{
    public class Estilos
    {
        [Key]
        public int IDEspecialidad {get; set;}
        public string Descripcion { get; set;}
    }
}