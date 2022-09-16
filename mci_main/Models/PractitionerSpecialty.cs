using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mci_main.Models
{
    public class PractitionerSpecialty : MciBase
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Practitioner")]
        public int PracIdx { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Specialty")]
        public int SpecIdx { get; set; }
    }
}

