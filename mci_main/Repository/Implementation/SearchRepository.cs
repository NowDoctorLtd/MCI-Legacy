using mci_main.Models;
using mci_main.Data;

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
            query.ToLower();

            var results = new SearchResults();
            results.SearchQuery = query;
            // Results - any practitioner with a matching name, or any prac with a matching spec
            results.Practitioners = _mciContext.Practitioner
                .Where(x => x.Name.ToLower().Contains(query)).Select(x => x).ToList();

            var specialties = _mciContext.Practitioner
                .Where(x => x.PractitionerSpecialties
                    .Where(s => s.Specialty.Title.ToLower().Contains(query)).Any()
                    ).ToList();

            if (specialties.Any()) 
            {
                results.Practitioners.AddRange(specialties);
            }

            return results;
        }
    }
}

