/******************************
* MCI Review Model
* Author: Mark Brown
* Authored: 25/09/2022
******************************/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mci_main.Data
{
    public class Review : MciBase
    {
        [Required]
        [ForeignKey("Practitioner")]
        public int PracIdx { get; set; }
        public virtual Practitioner Practitioner { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string ReviewerName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateVisited { get; set; }

        // Todo: List of adjectives

        public Review()
        {
            this.DateVisited = DateTime.Now; 
        }

    }
}

