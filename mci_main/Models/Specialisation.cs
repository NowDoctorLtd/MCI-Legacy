/******************************
* MCI Specialisation Model
* Define what practitioners do in medicalese
*
* Author: Mark Brown
* Authored: 10/09/2022
******************************/

using System;
using System.ComponentModel.DataAnnotations;

namespace mci_main.Models
{
    public class Specialty : MciBase
    {
        [Required]
        public string Title { get; set; }
        public string LongDescription { get; set; }
        public string ShortDesc { get; set; }

        public List<Practitioner> Practitioners { get; set; }
    }
}

