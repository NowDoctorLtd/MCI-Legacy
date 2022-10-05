/******************************
* MCI Search Controller
* Search results for public
* Author: Mark Brown
* Authored: 17/09/2022
******************************/
using mci_main.Repository;
using Microsoft.AspNetCore.Mvc;

namespace mci_main.Controllers
{
    public class SearchController : Controller
    {
        private ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository; 
        }

        // GET: Search
        [HttpGet]
        public string Index()
        {
            return "No query. Please leave.";
        }

        // POST: Search
        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Index(string query)
        {
            var resultsModel = _searchRepository.Search(query);

            return View(resultsModel);
        }

        // GET: SearchLite
        /* Queries specialties and   ailments by a search fragment in the string.
            used by the autocomplete drop down. Returns a JSON of the
            top matches.
        */
        [HttpGet]
        public ActionResult Lite([FromQuery] string query)
        {
            if (query == null || query.Length <=0)
            {
                return new EmptyResult();
            }
            var matches = _searchRepository.SearchLite(query);
            return Json(matches); 
        }

    }
}