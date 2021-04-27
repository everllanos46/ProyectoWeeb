using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class PlanAsignatura
    {
        [Key] [Column(TypeName="varchar(10)")]
        public String CodigoPlan{get; set;}
        public Asignatura Asignatura{get; set;}
        public String Descripcion { get; set; }
        public String ObjetivoGeneral { get; set; }
        public String ObjetivosEspecificos {get; set;}
        public String Estrategias { get; set; }
        
        

    }
}
