using System.ComponentModel.DataAnnotations;
using System;
namespace Empresa.Models
{
    public class Empresa
    {   
        [Key]
        public int IDEmpresa { get; set; }
        public string Nombre {get; set;}
        public string Ruc { get; set; }
        public string Telefono { get; set; }
        public string RazonSocial { get; set; }
        public DateTime HorarioAtencionDesde {get; set;}
        public DateTime HorarioAtencionHasta {get; set;}
        
    }
}