using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Services;

namespace DependencyInjection.Controllers;

public class HomeController : Controller
{
    public readonly ILog _ILog;
	public HomeController(ILog ilog)
	{
        _ILog = ilog;
	}
	public IActionResult Index()
    {
        _ILog.Info("Index Page(Constructor Injection)");
        return View();
    }

    public IActionResult Privacy([FromServices] ILog log)
    {
        log.Info("Privacy(Method Injection)");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
