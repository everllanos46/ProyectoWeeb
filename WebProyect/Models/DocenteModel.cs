using System;
using Entity;

namespace WebProyect.Models
{
    public class DocenteInputModel
    {
        public String Identificacion { get; set; }
        public String Correo { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Direccion { get; set; }
        public String Ciudad { get; set; }
        public String Pais { get; set; }
        public String SobreDocente { get; set; }
        public String Foto { get; set; }
        


    }

    public class DocenteViewModel : DocenteInputModel
    {
        public DocenteViewModel()
        {

        }

        public DocenteViewModel(Docente docente)
        {
            Identificacion=docente.Identificacion;
            Nombre=docente.Nombre;
            Correo=docente.Correo;
            Apellido=docente.Apellido;
            Direccion=docente.Direccion;
            Ciudad=docente.Ciudad;
            Pais=docente.Pais;
            SobreDocente=docente.SobreDocente;
            Foto=docente.Foto;
        }
    }
}