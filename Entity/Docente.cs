using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Docente
    {
        [Key] [Column(TypeName="varchar(10)")]
        public String Identificacion { get; set; }
        
        [Column(TypeName="varchar(25)")]
        public String Correo { get; set; }
        [Column(TypeName="varchar(20)")]
        public String Nombre { get; set; }
        [Column(TypeName="varchar(20)")]
        public String Apellido { get; set; }
        [Column(TypeName="varchar(20)")]
        public String Direccion { get; set; }
        [Column(TypeName="varchar(15)")]
        public String Ciudad { get; set; }
        [Column(TypeName="varchar(15)")]
        public String Pais { get; set; }
        [Column(TypeName="varchar(300)")]
        public String SobreDocente {get; set;}
        public String Foto {get; set;}
    }
}
