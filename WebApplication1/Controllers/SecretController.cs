using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAuthDemo.Controllers
{
	public class SecretController : Controller
	{
		[Authorize]
		public IActionResult AuthenticatedOnly() => View();

		[Authorize(Roles = "Admin")]
		public IActionResult AdminOnly() => View();

		[Authorize(Policy = "RequireDepartmentClaim")]
		public IActionResult DepartmentOnly() => View();
	}
}
