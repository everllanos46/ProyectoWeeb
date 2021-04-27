using Microsoft.AspNetCore.Mvc;
using BLL;
using Entity;
using DAL;
using WebProyect.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace WebProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaController : ControllerBase
    {
        private PlanAsignaturaService _planAsignaturaService;
        private AsignaturaService _AsignaturaService;

        public AsignaturaController(AsignaturaContext asignaturaContext)
        {
            _planAsignaturaService = new PlanAsignaturaService(asignaturaContext);
            _AsignaturaService = new AsignaturaService(asignaturaContext);
        }

        [HttpGet("{codigo}")]
        public ActionResult<PlanAsignaturaViewModel> BuscarAsignatura(string codigo){
            var Response = _planAsignaturaService.ConsultarPlan();
            if(Response.Error){
                ModelState.AddModelError("Error al buscar al plan", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status404NotFound;
                return BadRequest(detalleProblemas);
            }
            var planAsignatura = Response.PlanAsignaturas.Find(p=>p.Asignatura.Codigo.Equals(codigo));
            return Ok(planAsignatura);
        }

        [HttpGet]
        public ActionResult<AsignaturaViewModel> BuscarAsignaturas(){
            var Response = _AsignaturaService.ConsultarAsignaturas();
            if(Response.Error){
                ModelState.AddModelError("Error al buscar al plan", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status404NotFound;
                return BadRequest(detalleProblemas);
            }
            var asignaturas = Response.Asignaturas;
            return Ok(asignaturas);
        }

        [HttpPut("asignatura")]
         public ActionResult<AsignaturaViewModel> ModificarAsignatura(  AsignaturaViewModel asignaturaViewModel){
            Asignatura asignatura = Mapear(asignaturaViewModel);
            var Response = _AsignaturaService.EditarAsignatura(asignatura);
            if(Response.Error){
                ModelState.AddModelError("Error al modificar a la asignatura", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            return Ok(Response);
        }

        private Asignatura Mapear(AsignaturaInputModel asignaturaInputModel)
        {
            var asignatura = new Asignatura
            {
                Codigo=asignaturaInputModel.Codigo,
                Creditos=asignaturaInputModel.Creditos,
                Corequisitos=asignaturaInputModel.Corequisitos,
                DepartamentoOferente=asignaturaInputModel.DepartamentoOferente,
                Habilitable=asignaturaInputModel.Habilitable,
                HDD=asignaturaInputModel.HDD,
                Homologable=asignaturaInputModel.Homologable,
                HTI=asignaturaInputModel.HTI,
                HTP=asignaturaInputModel.HTP,
                HTT=asignaturaInputModel.HTT,
                NombreAsignatura=asignaturaInputModel.NombreAsignatura,
                Prerequisitos=asignaturaInputModel.Prerequisitos,
                ProgramaAcademico=asignaturaInputModel.ProgramaAcademico,
                TipoAsignatura=asignaturaInputModel.TipoAsignatura,
                Validable=asignaturaInputModel.Validable
            };
            return asignatura;
        }

    }
}