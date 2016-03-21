using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Models
{
    [Bind(Include = "CourseID,Horario,HDesde,HHasta,Dia")] 
    public class VMHorario
    {
        public int CourseID{ get; set; }
        public Horario Horario { get; set; }
        public SemanaDiasNombres Dia { get; set; }
        public Hora HDesde { get; set; }
        public Hora HHasta { get; set; }
        public VMHorario ()
        { Horario = new Horario();
        }
        public enum SemanaDiasNombres
        {
            Lunes= 1,
            Martes,
            Miercoles,
            Jueves,
            Viernes,
            Sabado
        }

        public struct Hora
        {            
            public int Horas { get; set; }
            public int Minutos { get; set; }
        }
    }
}