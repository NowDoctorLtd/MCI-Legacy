/******************************
* MCI Adjective Model
* Author: Mark Brown
* Authored: 25/09/2022
******************************/
using System.ComponentModel.DataAnnotations;

namespace mci_main.Data
{
    public class Adjective : MciBase
    {
        [Required]
        public string Name { get; set; }
        public int Rank { get; set; }

        /* WARNING: Temporary constructor, not for Db use! */
        public Adjective (string name, int mciIdx = -2, int rank = 0)
        {
            this.Name = name;
            this.MciIdx = -1;
            this.Rank = rank;
            this.DateCreated = DateTime.Now;
            this.MciIdx = mciIdx;
        }

        public Adjective() { }
    }

}

