using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studentska_Evidencija_PIN.Models
{
    public class Ispit
    {
        public int ID { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int PredmetID { get; set; }
        public Predmet Predmet { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum ispita")]
        public DateTime Datum_ispita { get; set; }

        public int nastavnikID { get; set; }
        public Nastavnik Nastavnik { get; set; }

        [Display(Name = "Ocjena")]
        public int ocjena { get; set; }
    }
}
