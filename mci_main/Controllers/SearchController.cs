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

    }
}