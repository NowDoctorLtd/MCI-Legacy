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
                .Where(x => x.Name.ToLower().Contains(query)).Select(x => x).ToList();

            var viewPractitioners = PractitionerHelper.DbListToViewList(dbPractitioners);

            var dbPracsWithSpecialties = _mciContext.Practitioner.Include("PractitionerSpecialties.Specialty")
                .Where(x => x.PractitionerSpecialties
                    .Where(s => s.Specialty.Title.ToLower().Contains(query)).Any()
                 ).ToList();

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
            matches = _mciContext.Specialty.Take(15)
                .Where(x => x.Title.ToLower().StartsWith(query)).Select(x => x.Title).ToList();

            return new SearchResultsLite() { Specialties = matches };
        }
    }
}

