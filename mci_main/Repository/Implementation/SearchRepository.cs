using System;
using mci_main.Models;

namespace mci_main.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private MciContext _context;

        public SearchRepository(MciContext context)
        {
            _context = context;
        }

        public SearchResults Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return new SearchResults(); 
            }

            query.ToLower();
            var results = new SearchResults();
            results.Practitioners = _context.Practitioner
                .Where(x => x.Name.ToLower().Contains(query) || x.Specialties.Any(s => s.Title.ToLower().Contains(query))).ToList();
            return results;
        }
    }
}

