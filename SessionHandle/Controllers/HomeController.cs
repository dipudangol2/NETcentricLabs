using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionHandle.Models;

namespace SessionHandle.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    //Set Tempdata
    public IActionResult Index()
    {
    TempData["message"] = "This is a temporary data";
        HttpContext.Session.SetString("SessionUser", "Dipu Dangol");

        var reqTime = HttpContext.Items["reqTime"] = DateTime.Now.ToString();
        ViewBag.reqTime = reqTime;
        HttpContext.Session.SetString("reqTime", DateTime.Now.ToString());
        return View();
    }

    public IActionResult DemoState()
    {
        var tempMessage = TempData["message"]?.ToString()?? "Expired!";
        var sessionUser = HttpContext.Session.GetString("SessionUser") ?? "Session Expired or not set!";
        Console.WriteLine(HttpContext.Items["reqTime"]);
        var requestTime = HttpContext.Session.GetString("reqTime")??"Request Time not set or is Expired!";

        ViewBag.Message = tempMessage;
        ViewBag.SessionUser = sessionUser;
        ViewBag.RequestTime = requestTime;

        return View();
    }
    public IActionResult EliminateSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("DemoState");
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
