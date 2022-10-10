/******************************
* MCI Specialty Model
* Define what practitioners do in medicalese
*
* Author: Mark Brown
* Authored: 10/09/2022
******************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace mci_main.Data
{
    public class Specialty : MciBase
    {
        [Required]
        public string Title { get; set; }
        // public string Nominative { get; set; } // i.e. -ist, required.
        public string LongDescription { get; set; }
        public string ShortDesc { get; set; }

        public virtual ICollection<PractitionerSpecialty> PractitionerSpecialties { get; set; }
    }
}

