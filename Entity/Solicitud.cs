using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Solicitud
    {
        [Key] [Column(TypeName="varchar(10)")]
        public String CodigoSolicitud { get; set; }
        public String Solicitante{get; set;}
        public String Estado{get; set;}
        public PlanSolicitud PlanSolicitud{get; set;}
    }
}