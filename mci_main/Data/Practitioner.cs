/******************************
* MCI Practitioner Model
* Defines practitioners of all stripes and types.
*
* Author: Mark Brown
* Authored: 10/09/2022
******************************/

using System.ComponentModel.DataAnnotations;

namespace mci_main.Data
{
    public class Practitioner : MciBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Title Title { get; set; }
        public virtual ICollection<PractitionerSpecialty> PractitionerSpecialties { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }

    public enum Title
    {
        Dr, Mr, Mrs, Miss, Ms, Lord, Cpl, Pope
    }
}

