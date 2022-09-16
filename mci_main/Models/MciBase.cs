using System;
using System.ComponentModel.DataAnnotations;

namespace mci_main.Models
{
    public abstract class MciBase
    {
        [Key]
        public int MciIdx { get; set; }
    }
}

