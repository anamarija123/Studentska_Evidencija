using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Studentska_Evidencija_PIN.Models
{
    public class Smjer
    {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    [Required]
    [StringLength(15, ErrorMessage = "maksimalno 15 znakova")]
    [Display(Name = "Naziv Smjera")]
    public string Naziv { get; set; }

    [Required]
    public int ECTS { get; set; }
}
}
