using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mci_main.Data
{
    public abstract class MciBase
    {
        [Key]
        [Column(Order = 1)]
        public int MciIdx { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
    }
}

