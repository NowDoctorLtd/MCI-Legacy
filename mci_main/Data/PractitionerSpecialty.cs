using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mci_main.Data
{
    public class PractitionerSpecialty : MciBase
    {
        // Col 1 = MciIdx
        [Column(Order = 2)]
        [ForeignKey("Practitioner")]
        public int PracIdx { get; set; }
        public virtual Practitioner Practitioner { get; set; }
        [Column(Order = 3)]
        [ForeignKey("Specialty")]
        public int SpecIdx { get; set; }
        public virtual Specialty Specialty { get; set; }
    }
}

