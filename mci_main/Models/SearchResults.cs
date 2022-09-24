using System;
using mci_main.Data;
namespace mci_main.Models
{
    public class SearchResults
    {
        public List<Practitioner>? Practitioners { get; set; }
        public List<Specialty>? LikeSpecilisations { get; set; }
        public string? SearchQuery { get; set; }

        public SearchResults()
        { 
        }
    }
}
