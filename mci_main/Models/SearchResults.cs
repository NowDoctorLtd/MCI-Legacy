using mci_main.Data;
using mci_main.Models.View;
namespace mci_main.Models
{
    public class SearchResults
    {
        public List<PractitionerViewModel>? Practitioners { get; set; }
        public List<Specialty>? LikeSpecilisations { get; set; }
        public string? SearchQuery { get; set; }

        public SearchResults()
        { 
        }
    }
}
