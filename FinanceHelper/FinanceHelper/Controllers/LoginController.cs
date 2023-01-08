using FinanceHelper.Models;
using Microsoft.AspNetCore.Mvc;
using FinanceHelper.Repository;

namespace FinanceHelper.Controllers {
	public class LoginController : Controller {

		private readonly IUserRepository _userRespository;

		public LoginController(IUserRepository userRespository) {
			_userRespository = userRespository;
		}

		public IActionResult Index() {
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginModel loginModel) {
			try {
				if (ModelState.IsValid) {

					UserModel user = _userRespository.GetUserByLogin(loginModel.Login);

					if (user is not null) {

						if (user.PasswordIsValid(loginModel.Password)) {
							return RedirectToAction("Index", "Home");
						}
						TempData["ErrorMessage"] = "Senha do usuário é inválida. Por favor, tente novamente!";

					}
					else {
						TempData["ErrorMessage"] = "Usuário ou senha inválido(s). Por favor, tente novamente!";
					}
					

				}
				return View("Index");
			}
			catch (Exception error) {

				TempData["ErrorMessage"] = $"Ops! Não foi possível realizar o seu login. {error}";
				return RedirectToAction("Index");
			}
		}
	}
}
