using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OMGD_API.Models;

namespace OMGD_API.Controllers;

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
    public IActionResult MovieSearch() //From Form in MovieSearch view
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieSearch(string Title) //Sends back to MovieSearch view
    {
        return View(MovieDAL.GetMovie(Title));
    }


    [HttpGet]
    public IActionResult MovieNight() //From Form in MovieNight view
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieNight(string Title1, string Title2, string Title3) //Sends back to MovieNight view
    {
        List<Movie> result = new List<Movie>().ToList();

        result.Add(MovieDAL.GetMovie(Title1));
        result.Add(MovieDAL.GetMovie(Title2));
        result.Add(MovieDAL.GetMovie(Title3));

        return View(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

