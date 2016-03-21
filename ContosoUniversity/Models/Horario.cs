using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Models
{
    [Bind(Include = "ID,CourseID,DiaSemana")] 
    public class Horario
    {
        public int ID { get;set; }
        public int CourseID { get; set; }
        public int DiaSemana { get; set; }        
        public TimeSpan  HoraDesde { get; set; }        
        public TimeSpan HoraHasta { get; set; }

        public virtual Course Course { get; set; }
    }

}