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
    public class SolicitudController : ControllerBase
    {
        private SolicitudService _solicitudService;

        public SolicitudController(AsignaturaContext asignaturaContext)
        {
            _solicitudService = new SolicitudService(asignaturaContext);
        }

        [HttpPost]
        public ActionResult<SolicitudViewModel> GuardarSolicitud(SolicitudInputModel solicitudInputModel){
            Solicitud solicitud = Mapear(solicitudInputModel);
            var Response = _solicitudService.HacerSolicitud(solicitud);
            if(Response.Error){
                ModelState.AddModelError("Error al guardar la solicitud", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                if(Response.Estado.Equals("EXISTE")){
                    detalleProblemas.Status=StatusCodes.Status302Found;
                }
                if(Response.Error.Equals("ERROR")){
                    detalleProblemas.Status=StatusCodes.Status500InternalServerError;
                }
                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Solicitud);
        }

        [HttpGet]
        public ActionResult<SolicitudViewModel> ConsultarSolicitudes( ){
            var Response = _solicitudService.ConsultarSolicitudes();
            if(Response.Error){
                ModelState.AddModelError("Error al consultar a las solicitudes", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            return Ok(Response.Solicitudes.Select(s=> new SolicitudViewModel(s)));
        }

        [HttpGet("{codigo}")]
        public ActionResult<SolicitudViewModel> BuscarSolicitud(string codigo){
            var Response = _solicitudService.ConsultarSolicitudes();
            if(Response.Error){
                 ModelState.AddModelError("Error al buscar a la solicitud", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status404NotFound;
                return BadRequest(detalleProblemas);
            }
            var solicitud = Response.Solicitudes.Find(s=>s.CodigoSolicitud.Equals(codigo));
            return Ok(solicitud);
        }

        [HttpPut("solicitud")]
         public ActionResult<SolicitudViewModel> CambiarEstado(SolicitudViewModel solicitudViewModel){
            Solicitud solicitud = Mapear(solicitudViewModel);
            var Response = _solicitudService.ActualizarSolicitud(solicitud);
            if(Response.Error){
                ModelState.AddModelError("Error al modificar al docente", Response.Mensaje);
                var detalleProblemas = new ValidationProblemDetails(ModelState);
                detalleProblemas.Status=StatusCodes.Status500InternalServerError;

                return BadRequest(detalleProblemas);
            }
            return Ok(Response);
        }

        

        private Solicitud Mapear(SolicitudInputModel solicitudInputModel){
            var solicitud = new Solicitud{
                CodigoSolicitud=solicitudInputModel.CodigoSolicitud,
                Estado=solicitudInputModel.Estado,
                PlanSolicitud=solicitudInputModel.PlanSolicitud,
                Solicitante=solicitudInputModel.Solicitante
            };
            return solicitud;
        }
        
    }
}