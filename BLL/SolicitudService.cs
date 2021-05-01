using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class SolicitudService
    {
         private AsignaturaContext _AsignaturaContext;

        public SolicitudService(AsignaturaContext asignaturaContext)
        {
            _AsignaturaContext = asignaturaContext;
        }

        public HacerSolicitudResponse HacerSolicitud(Solicitud solicitud){
            try{
                var Respuesta = _AsignaturaContext.Solicitudes.Find(solicitud.CodigoSolicitud);
                if(Respuesta==null){
                    solicitud.PlanSolicitud.IdAsignatura=solicitud.PlanSolicitud.Asignatura.Codigo;
                    _AsignaturaContext.Solicitudes.Add(solicitud);
                    _AsignaturaContext.SaveChanges();
                    return new HacerSolicitudResponse(solicitud);
                }else{
                    return new HacerSolicitudResponse("Ya se encuentra este plan de asignatura", "EXISTE");
                }
            }catch(Exception e){
                 return new HacerSolicitudResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        public ConsultarSolicitudesResponse ConsultarSolicitudes()
        {
            ConsultarSolicitudesResponse consultarSolicitudesResponse = new ConsultarSolicitudesResponse();
            try
            {
                consultarSolicitudesResponse.Error = false;
                consultarSolicitudesResponse.Mensaje = "Consultado correctamente";
                consultarSolicitudesResponse.Solicitudes = _AsignaturaContext.Solicitudes.Include(p => p.PlanSolicitud).ToList();

                foreach (var item in consultarSolicitudesResponse.Solicitudes)
                {
                    item.PlanSolicitud.Asignatura=_AsignaturaContext.Asignaturas.Find(item.PlanSolicitud.IdAsignatura);
                    
                }
            }
            catch (Exception e)
            {
                consultarSolicitudesResponse.Error = true;
                consultarSolicitudesResponse.Mensaje = $"Hubo un error al momento de consultar, {e.Message}";
                consultarSolicitudesResponse.Solicitudes =null;
            }
            return consultarSolicitudesResponse;
        }





        public class ConsultarSolicitudesResponse{
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public List<Solicitud> Solicitudes{get;set;}
        }
        public class HacerSolicitudResponse{
             public HacerSolicitudResponse(Solicitud solicitud)
            {
                Error = false;
                Solicitud = solicitud;
            }

            public HacerSolicitudResponse(String Message, String Estate)
            {
                Error = true;
                Mensaje = Message;
                Estado = Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public Solicitud Solicitud { get; set; }
            public String Estado { get; set; }
        }
        
    }
}