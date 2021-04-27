using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class PlanAsignaturaService
    {
        private AsignaturaContext _AsignaturaContext;

        public PlanAsignaturaService(AsignaturaContext asignaturaContext)
        {
            _AsignaturaContext = asignaturaContext;
        }

        public GuardarPlanResponse GuardarPlan(PlanAsignatura planAsignatura)
        {
            try
            {
                var Respuesta = _AsignaturaContext.PlanAsignaturas.Find(planAsignatura.CodigoPlan);
                if (Respuesta == null)
                {
                    _AsignaturaContext.PlanAsignaturas.Add(planAsignatura);
                    _AsignaturaContext.SaveChanges();
                    return new GuardarPlanResponse(planAsignatura);
                }
                else
                {
                    return new GuardarPlanResponse("Ya se encuentra este plan de asignatura", "EXISTE");
                }
            }
            catch (Exception e)
            {
                return new GuardarPlanResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        

        public ConsultarPlanResponse ConsultarPlan()
        {
            ConsultarPlanResponse consultarPlanResponse = new ConsultarPlanResponse();
            try
            {
                consultarPlanResponse.Error = false;
                consultarPlanResponse.Mensaje = "Consultado correctamente";
                consultarPlanResponse.PlanAsignaturas = _AsignaturaContext.PlanAsignaturas.Include(p => p.Asignatura).ToList();
            }
            catch (Exception e)
            {
                consultarPlanResponse.Error = true;
                consultarPlanResponse.Mensaje = $"Hubo un error al momento de consultar, {e.Message}";
                consultarPlanResponse.PlanAsignaturas =null;
            }
            return consultarPlanResponse;
        }

        public class EliminarPlanResponse
        {
            public bool Error { get; set; }
            public String Mensaje { get; set; }
        }

        public class EditarPlanResponse
        {
            public String Mensaje { get; set; }
            public bool Error { get; set; }
        }

        public class EditarAsignaturaResponse{
            public String Mensaje { get; set; }
            public bool Error { get; set; }
        }

        public class ConsultarPlanResponse
        {
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public List<PlanAsignatura> PlanAsignaturas { get; set; }
        }

        public class GuardarPlanResponse
        {
            public GuardarPlanResponse(PlanAsignatura planAsignatura)
            {
                Error = false;
                PlanAsignatura = planAsignatura;
            }

            public GuardarPlanResponse(String Message, String Estate)
            {
                Error = true;
                Mensaje = Message;
                Estado = Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public PlanAsignatura PlanAsignatura { get; set; }
            public String Estado { get; set; }
        }
    }
}