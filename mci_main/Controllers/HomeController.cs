/******************************
* MCI Home Controller
* Index route and search.
*
* Author: Mark Brown
* Authored: 10/09/2022
******************************/

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mci_main.Models;
using System.Text.Encodings.Web;
using mci_main.Repository;

namespace mci_main.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISearchRepository _searchRepository;

    public HomeController(ILogger<HomeController> logger, ISearchRepository search)
    {
        _logger = logger;
        _searchRepository = search;
    }

    public IActionResult Index()
    {
        ViewData["QueryExamples"] = _searchRepository.GetQueryExamples();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Search()
    {
        return View(); 
    }

    [HttpPost]
    public string Search(string query)
    {
        return HtmlEncoder.Default.Encode(query); 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

