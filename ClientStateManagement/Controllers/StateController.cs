using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ClientStateManagement.Controllers
{
	public class StateController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Submit(string username,string hiddenValue)
		{
			CookieOptions option = new CookieOptions();
			option.Expires = DateTime.Now.AddMinutes(60);
			Response.Cookies.Append("username", username, option);
			Response.Cookies.Append("HiddenFieldValue", hiddenValue);
			return RedirectToAction("QueryAndCookie",new{city = "Kathmandu" });
		}
		public IActionResult QueryAndCookie(string city)
		{
			string user = Request.Cookies["username"] ?? "Guest";
			string hiddenValue = Request.Cookies["HiddenFieldValue"] ?? "no data";
			ViewBag.User = user;
			ViewBag.City = city;
			ViewBag.Hidden = hiddenValue;
			return View();
		}

	


	}

}
