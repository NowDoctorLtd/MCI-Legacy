using System.ComponentModel;
using mci_main.Data;
namespace mci_main.Models.View;

public class PractitionerViewModel { 

        public int MciIdx { get; set; }
        public string Name { get; set; }
        public Title Title { get; set; }
        [DisplayName("Specialties")]
        public string SpecialtiesStr { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
        public Dictionary<int, string> ReviewsInBrief { get; set; }
        public string Img { get; set; }
        public List<string> Adjectives { get; set; }

}
