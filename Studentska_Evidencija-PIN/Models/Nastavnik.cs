using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studentska_Evidencija_PIN.Models
{
    public class Nastavnik
    {
    public int ID { get; set; }

    [Required]
    [StringLength(15, ErrorMessage = "maksimalno 15 znakova")]
    public string Ime { get; set; }

    [Required]
    [StringLength(15, ErrorMessage = "maksimalno 15 znakova")]
    public string Prezime { get; set; }

    [DataType(DataType.Date), Display(Name = "Datum zaposlenja"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DatumZaposlenja { get; set; }

    public string ImeiPrezime
    {
        get
        {
            return Ime + ", " + Prezime;
        }
    }
}
}
