using System;
using Entity;
namespace WebProyect.Models
{
    public class PlanSolicitudInputModel
    {
        public Asignatura Asignatura{get; set;}
        public String CodigoPlan{get; set;}
        public String Descripcion { get; set; }
        public String ObjetivoGeneral { get; set; }
        public String ObjetivosEspecificos {get; set;}
        public String Estrategias { get; set; }
    }

    public class PlanSolicitudViewModel : PlanAsignaturaInputModel
    {
        public PlanSolicitudViewModel()
        {
            
        }


        public PlanSolicitudViewModel(PlanSolicitud planSolicitud)
        {
            Asignatura=planSolicitud.Asignatura;
            CodigoPlan=planSolicitud.CodigoPlan;
            Descripcion=planSolicitud.Descripcion;
            ObjetivoGeneral=planSolicitud.ObjetivoGeneral;
            ObjetivosEspecificos=planSolicitud.ObjetivosEspecificos;
            Estrategias=planSolicitud.Estrategias;
        }
    }
}