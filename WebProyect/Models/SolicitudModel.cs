using System;
using Entity;

namespace WebProyect.Models
{
    public class SolicitudInputModel
    {
        public String CodigoSolicitud { get; set; }
        public PlanSolicitud PlanSolicitud{get; set;}
        public String Solicitante{get; set;}
        public String Estado{get; set;}
    }

    public class SolicitudViewModel : SolicitudInputModel
    {
        public SolicitudViewModel()
        {
            
        }

        public SolicitudViewModel(Solicitud solicitud)
        {
            CodigoSolicitud=solicitud.CodigoSolicitud;
            PlanSolicitud=solicitud.PlanSolicitud;
            Solicitante=solicitud.Solicitante;
            Estado=solicitud.Estado;
            
        }




    }


}