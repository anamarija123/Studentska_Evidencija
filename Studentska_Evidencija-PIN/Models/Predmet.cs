using System.ComponentModel.DataAnnotations;

namespace Studentska_Evidencija_PIN.Models
{
    public class Predmet
    {
    public int ID { get; set; }

    [Display(Name = "Naziv predmeta")]
    public string naziv { get; set; }

    public int smjerId { get; set; }
    [Display(Name = "Smjer")]
    public Smjer smjer { get; set; }

    }   
}
