using mci_main.Data;
namespace mci_main.Models.View;

public class PractitionerViewModel { 

        public int MciIdx { get; set; }
        public string Name { get; set; }
        public Title Title { get; set; }
        public string SpecialtiesStr { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }

}
