/******************************
* MCI Practitioner Model
* Defines practitioners of all stripes and types.
*
* Author: Mark Brown
* Authored: 10/09/2022
******************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mci_main.Models
{
    public class Practitioner : MciBase
    {
        [Required]
        public string Name { get; set; }
  //    [Required]
        public Title Title { get; set; }
 //     [Required]
        public List<Specialty> Specialties { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
//      [Required] 
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

    }

    public enum Title
    { 
        Dr, Mr, Mrs, Miss, Ms, Lord, Cpl, Pope
    }
}

