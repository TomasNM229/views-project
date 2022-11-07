using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace views_project.Models
{
    public class Publico
    {
        [Key]
        public int IDPublico {get; set;}
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Edad {get; set;}
        public string Correo {get; set;}
        public string Telefono {get; set;}
    }
}