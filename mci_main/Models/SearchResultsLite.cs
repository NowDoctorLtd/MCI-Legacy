using System;
namespace mci_main.Models
{
    public class SearchResultsLite
    {
        public List<string> Specialties { get; set; }

        public SearchResultsLite() 
        {
            this.Specialties = new List<string>();
        }

        public SearchResultsLite(List<string> specialties) 
        {
            this.Specialties = specialties;
        }
    }
}

