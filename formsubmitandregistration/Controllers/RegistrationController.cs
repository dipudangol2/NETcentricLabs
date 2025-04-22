using Microsoft.AspNetCore.Mvc;
using formsubmitandregistration.Controllers;

using formsubmitandregistration.Models;

namespace formsubmitandregistration.Controllers
{
	public class RegistrationController :Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(UserViewModel model)
		{
			if (ModelState.IsValid)
			{
				return View("Result", model);
			}
			return View(model);
		}
	}
}
