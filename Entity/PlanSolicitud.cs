using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class PlanSolicitud
    {
        [Key] [Column(TypeName="varchar(10)")]
        public String CodigoPlan{get; set;}
        [NotMapped] 
        public Asignatura Asignatura{get; set;}
        public String IdAsignatura{get; set;}
        public String Descripcion { get; set; }
        public String ObjetivoGeneral { get; set; }
        public String ObjetivosEspecificos {get; set;}
        public String Estrategias { get; set; }
    }
}