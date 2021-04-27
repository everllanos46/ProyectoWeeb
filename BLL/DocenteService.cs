using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entity;


namespace BLL
{
    public class DocenteService
    {
        private AsignaturaContext _AsignaturaContext;
        public DocenteService(AsignaturaContext asignaturaContext)
        {
            _AsignaturaContext=asignaturaContext;
        }

        public GuardarDocenteResponse GuardarDocente(Docente docente){
            try{
                var Respuesta=_AsignaturaContext.Docentes.Find(docente.Identificacion);
                if(Respuesta==null){
                    _AsignaturaContext.Docentes.Add(docente);
                    _AsignaturaContext.SaveChanges();
                    return new GuardarDocenteResponse(docente);
                } else{
                    return new GuardarDocenteResponse("Ya se encuentra este docente", "EXISTE");
                }
            } catch(Exception e){
                return new GuardarDocenteResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        public DocenteConsultarResponse ConsultarDocentes(){
            DocenteConsultarResponse docenteConsultarResponse = new DocenteConsultarResponse();
            try{
                docenteConsultarResponse.Error=false;
                docenteConsultarResponse.Mensaje="Docentes consultados correctamente";
                docenteConsultarResponse.Docentes=_AsignaturaContext.Docentes.ToList();
            } catch(Exception e){
                docenteConsultarResponse.Error=true;
                docenteConsultarResponse.Mensaje=$"Hubo un error al momento de consultar, {e.Message}";
                docenteConsultarResponse.Docentes=null;
            
            }
            return docenteConsultarResponse;
        }

        public EliminarDocenteResponse EliminarDocente(string identificacion){
            EliminarDocenteResponse eliminarDocenteResponse = new EliminarDocenteResponse();
            try{
                eliminarDocenteResponse.Error=false;
                eliminarDocenteResponse.Mensaje="Docente eliminado correctamente";
                var resul= _AsignaturaContext.Docentes.Find(identificacion);
                _AsignaturaContext.Remove(resul);
                _AsignaturaContext.SaveChanges();
            }catch(Exception e){
                eliminarDocenteResponse.Error=true;
                eliminarDocenteResponse.Mensaje=$"Hubo un error al momento de eliminar al docente, {e.Message}";
            }

            return eliminarDocenteResponse;
        }

        public EditarDocenteResponse EditarDocente(Docente docente){
            EditarDocenteResponse editarDocenteResponse = new EditarDocenteResponse();
            try{
                editarDocenteResponse.Error=false;
                editarDocenteResponse.Mensaje="Persona editada correctamente";
                var resul=_AsignaturaContext.Docentes.Find(docente.Identificacion);
                resul.Nombre=docente.Nombre;
                resul.Apellido=docente.Apellido;
                resul.Ciudad=docente.Ciudad;
                resul.Correo=docente.Correo;
                resul.Direccion=docente.Direccion;
                resul.Pais=docente.Pais;
                resul.SobreDocente=docente.SobreDocente;
                _AsignaturaContext.Docentes.Update(resul);
                _AsignaturaContext.SaveChanges();
            } catch(Exception e){
                editarDocenteResponse.Error=true;
                editarDocenteResponse.Mensaje=$"Hubo un error al momento de editar al docente, {e.Message}";
            }
            return editarDocenteResponse;
        }

        public class EliminarDocenteResponse{
            public bool Error { get; set; }
            public String Mensaje { get; set; }
        }

        public class EditarDocenteResponse{
            public String Mensaje {get; set;}
            public bool Error{get; set;}
        }

        public class GuardarDocenteResponse{
            public GuardarDocenteResponse(Docente docente)
            {
                Error=false;
                Docente=docente;
            }

            public GuardarDocenteResponse(String Message, String Estate)
            {
                Error=true;
                Mensaje=Message;
                Estado=Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public Docente Docente { get; set; }
            public String Estado { get; set; }
        }

        public class DocenteConsultarResponse{
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public List<Docente> Docentes{get;set;}
            
        }
    }
}
