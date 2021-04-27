using System;
using Entity;

namespace WebProyect.Models
{
    public class PlanAsignaturaInputModel
    {
        public Asignatura Asignatura{get; set;}
        public String CodigoPlan{get; set;}
        public String Descripcion { get; set; }
        public String ObjetivoGeneral { get; set; }
        public String ObjetivosEspecificos {get; set;}
        public String Estrategias { get; set; }
    }

    public class PlanAsignaturaViewModel : PlanAsignaturaInputModel
    {
        public PlanAsignaturaViewModel()
        {
            
        }


        public PlanAsignaturaViewModel(PlanAsignatura planAsignatura)
        {
            Asignatura=planAsignatura.Asignatura;
            CodigoPlan=planAsignatura.CodigoPlan;
            Descripcion=planAsignatura.Descripcion;
            ObjetivoGeneral=planAsignatura.ObjetivoGeneral;
            ObjetivosEspecificos=planAsignatura.ObjetivosEspecificos;
            Estrategias=planAsignatura.Estrategias;
        }
    }
}