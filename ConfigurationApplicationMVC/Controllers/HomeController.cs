using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConfigurationApplicationMVC.Models;

namespace ConfigurationApplicationMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TestWebConfig _config;

    public HomeController(ILogger<HomeController> logger,TestWebConfig config)
    {
        _logger = logger;
        _config = config;
    }

    public IActionResult Index()
    {
        _config.Test();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}