using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Asignatura
    {
        [Key] [Column(TypeName = "varchar(10)")]
        public String Codigo { get; set; }

      
        public String NombreAsignatura { get; set; }

       
        public int Creditos { get; set; }

       
        public String ProgramaAcademico { get; set; }

       
        public int HDD { get; set; }
      
        public int HTP { get; set; }
       
        public int HTI { get; set; }
       
        public int HTT { get; set; }
        public String Prerequisitos { get; set; }
        public String Corequisitos { get; set; }
        public String DepartamentoOferente { get; set; }
        public String TipoAsignatura { get; set; }
        public String Habilitable { get; set; }
        public String Validable { get; set; }
        public String Homologable { get; set; }

    }
}