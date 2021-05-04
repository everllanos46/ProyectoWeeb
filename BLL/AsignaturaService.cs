using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class AsignaturaService
    {
        private AsignaturaContext _AsignaturaContext;
        private PlanAsignaturaService planAsignaturaService;
        private SolicitudService solicitudService;

        public AsignaturaService(AsignaturaContext asignaturaContext)
        {
            _AsignaturaContext = asignaturaContext;
            planAsignaturaService = new PlanAsignaturaService(asignaturaContext);
            solicitudService = new SolicitudService(asignaturaContext);
        }

        public EditarAsignaturaResponse EditarAsignatura(Asignatura asignatura){
            EditarAsignaturaResponse editarAsignaturaResponse = new EditarAsignaturaResponse();
            try{
                editarAsignaturaResponse.Error=false;
                editarAsignaturaResponse.Mensaje="Editada correctamente";
                var resul= _AsignaturaContext.Asignaturas.Find(asignatura.Codigo);
                resul.Corequisitos=asignatura.Corequisitos;
                resul.Creditos=asignatura.Creditos;
                resul.DepartamentoOferente=asignatura.DepartamentoOferente;
                resul.Habilitable=asignatura.Habilitable;
                resul.Homologable=asignatura.Homologable;
                resul.HDD=asignatura.HDD;
                resul.HTI=asignatura.HTI;
                resul.HTP=asignatura.HTP;
                resul.HTT=asignatura.HTT;
                resul.NombreAsignatura=asignatura.NombreAsignatura;
                resul.TipoAsignatura=asignatura.TipoAsignatura;
                _AsignaturaContext.Asignaturas.Update(resul);
                _AsignaturaContext.SaveChanges();
            }catch(Exception e){
                editarAsignaturaResponse.Error=true;
                editarAsignaturaResponse.Mensaje=$"Hubo un error al momento de editar, {e.Message}";
            }
            return editarAsignaturaResponse;
        }

        public ConsultarAsignaturasResponse ConsultarAsignaturas()
        {
            ConsultarAsignaturasResponse consultarAsignaturasResponse = new ConsultarAsignaturasResponse();
            try
            {
                consultarAsignaturasResponse.Error = false;
                consultarAsignaturasResponse.Mensaje = "Consultado correctamente";
                consultarAsignaturasResponse.Asignaturas = _AsignaturaContext.Asignaturas.ToList();
            }
            catch (Exception e)
            {
                consultarAsignaturasResponse.Error = true;
                consultarAsignaturasResponse.Mensaje = $"Hubo un error al momento de consultar, {e.Message}";
                consultarAsignaturasResponse.Asignaturas =null;
            }
            return consultarAsignaturasResponse;
        }

        public EliminarAsignaturaResponse EliminarAsignatura(string codigo){
            EliminarAsignaturaResponse eliminarAsignaturaResponse = new EliminarAsignaturaResponse();
            try{
                eliminarAsignaturaResponse.Error=false;
                eliminarAsignaturaResponse.Mensaje="Docente eliminado correctamente";
                var resul= _AsignaturaContext.Asignaturas.Find(codigo);
                planAsignaturaService.EliminarPlan(codigo);
                solicitudService.EliminarSolicitud(codigo);
                _AsignaturaContext.Remove(resul);
                _AsignaturaContext.SaveChanges();
            }catch(Exception e){
                eliminarAsignaturaResponse.Error=true;
                eliminarAsignaturaResponse.Mensaje=$"Hubo un error al momento de eliminar a la asignatura, {e.Message}";
            }

            return eliminarAsignaturaResponse;
        }


         public class EditarAsignaturaResponse{
            public String Mensaje { get; set; }
            public bool Error { get; set; }
        }

        public class EliminarAsignaturaResponse{
            public String Mensaje { get; set; }
            public bool Error { get; set; }
        }

        public class ConsultarAsignaturasResponse
        {
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public List<Asignatura> Asignaturas { get; set; }
        }
        
    }
}