using Microsoft.AspNetCore.Mvc;
using BLL;
using Entity;
using DAL;
using WebProyect.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace WebProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanAsignaturaController : ControllerBase
    {

        private PlanAsignaturaService _planAsignaturaService;

        public PlanAsignaturaController(AsignaturaContext asignaturaContext)
        {
            _planAsignaturaService = new PlanAsignaturaService(asignaturaContext);
        }

        [HttpPost]
        public ActionResult<PlanAsignaturaViewModel> GuardarPlan(PlanAsignaturaInputModel planAsignaturaInputModel)
        {
            PlanAsignatura planAsignatura = Mapear(planAsignaturaInputModel);
            var Response = _planAsignaturaService.GuardarPlan(planAsignatura);
            if (Response.Error)
            {
                ModelState.AddModelError("Error al guardar al plan de asignatura", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                if (Response.Estado.Equals("EXISTE"))
                {
                    detalleProblemas.Status = StatusCodes.Status302Found;
                }
                if (Response.Error.Equals("ERROR"))
                {
                    detalleProblemas.Status = StatusCodes.Status500InternalServerError;
                }
                return BadRequest(detalleProblemas);
            }
            return Ok(Response.PlanAsignatura);
        }

        [HttpGet]
        public ActionResult<PlanAsignaturaViewModel> ConsultarPlan( ){
            var Response = _planAsignaturaService.ConsultarPlan();
            if(Response.Error){
                ModelState.AddModelError("Error al consultar a las asignaturas", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            return Ok(Response.PlanAsignaturas.Select(p=> new PlanAsignaturaViewModel(p)));
        }

        [HttpGet("{codigo}")]
        public ActionResult<PlanAsignaturaViewModel> BuscarPlan(string codigo){
            var Response = _planAsignaturaService.ConsultarPlan();
            if(Response.Error){
                 ModelState.AddModelError("Error al buscar al plan", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status404NotFound;
                return BadRequest(detalleProblemas);
            }
            var planAsignatura = Response.PlanAsignaturas.Find(p=>p.CodigoPlan.Equals(codigo));
            return Ok(planAsignatura);
        }

        private PlanAsignatura Mapear(PlanAsignaturaInputModel planAsignaturaInputModel)
        {
            var planAsignatura = new PlanAsignatura
            {
                Asignatura = planAsignaturaInputModel.Asignatura,
                CodigoPlan = planAsignaturaInputModel.CodigoPlan,
                Descripcion = planAsignaturaInputModel.Descripcion,
                ObjetivoGeneral = planAsignaturaInputModel.ObjetivoGeneral,
                ObjetivosEspecificos = planAsignaturaInputModel.ObjetivosEspecificos,
                Estrategias = planAsignaturaInputModel.Estrategias
            };
            return planAsignatura;
        }


    }
}