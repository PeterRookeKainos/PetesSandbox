using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReadConfig.Models;

namespace ReadConfig.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppOptions _appOptions;

    /*
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    */
    
    public HomeController(ILogger<HomeController> logger, AppOptions appOptions)
    {
        _logger = logger;
        _appOptions = appOptions;
        _logger.LogInformation("AppOptions ExampleValue: {ExampleValue}", _appOptions.ExampleValue);
    }

    public IActionResult Index()
    {
        View().ViewData.Add("ExampleValue", _appOptions.ExampleValue);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
