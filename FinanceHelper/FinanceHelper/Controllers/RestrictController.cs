using FinanceHelper.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHelper.Controllers {

	[LoggedUserPage]
	public class RestrictController : Controller {
		public IActionResult Index() {
			return View();
		}
	}
}
