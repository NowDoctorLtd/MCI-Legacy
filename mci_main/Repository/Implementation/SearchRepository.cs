/******************************
* MCI Search Repository 
* Author: Mark Brown
* Authored: 16/09/2022
******************************/
using mci_main.Models;
using mci_main.Helpers;
using Microsoft.EntityFrameworkCore;

namespace mci_main.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private MciContext _mciContext;

        public SearchRepository(MciContext context)
        {
            _mciContext = context;
        }

        public SearchResults Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return new SearchResults(); 
            }

            var results = new SearchResults();
            results.SearchQuery = query;

            query = query.ToLower();

            // Results - any practitioner with a matching name, or any prac with a matching spec
            var dbPractitioners = _mciContext.Practitioner.Include("PractitionerSpecialties.Specialty")
                .Where(x => x.Name.ToLower().Contains(query)).ToList();

            var viewPractitioners = PractitionerHelper.DbListToViewList(dbPractitioners);

            var dbPracsWithSpecialties = _mciContext.Practitioner.Include("PractitionerSpecialties.Specialty")
                .Where(x => x.PractitionerSpecialties
                .Where(s => s.Specialty.Nominative.ToLower().Contains(query)).Any())
		        .ToList();

            results.Practitioners = viewPractitioners;

            if (dbPracsWithSpecialties.Any()) 
            {
                viewPractitioners = PractitionerHelper.DbListToViewList(dbPracsWithSpecialties);
                results.Practitioners.AddRange(viewPractitioners);
            }

            return results;
        }

        public SearchResultsLite SearchLite(string query)
        {
            List<string> matches;
            query = query.ToLower();
            
            // Match lower case, return top 15 (TODO: limit after order by applied)
            matches = _mciContext.Specialty
                .Where(x => x.Title.ToLower().StartsWith(query) || x.Nominative.ToLower().StartsWith(query))
	        	.Select(x => x.Nominative).Take(15).ToList();

            return new SearchResultsLite() { Specialties = matches };
        }

        // Temporary method, will cache from DB in future to all with at least one prac
        public string GetQueryExamples()
        {
            var rand = new Random();
            List<string> practitionerTitles = new List<string> {
                "Cardiologist", "Psychiatrist", "Paeditrician", "Psychologist",
                "Orthopaedic surgeon", "Pharmacist", "Dermatologist", "Obstetrician",
                "Gynaecologist", "Otologist", "Uriologist"
            };
            // Random select
            var egTitles = practitionerTitles.OrderBy(x => rand.Next()).Take(3).ToArray();
            return $"a {egTitles[0]}, a {egTitles[1]} or a {egTitles[2]}";
        }
    }
}

