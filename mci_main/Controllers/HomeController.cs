using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mci_main.Models;
using System.Text.Encodings.Web;

namespace mci_main.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult search()
    {
        return View(); 
    }

    [HttpPost]
    public string search(string query)
    {
        return HtmlEncoder.Default.Encode(query); 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

