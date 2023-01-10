using FinanceHelper.Models;
using Microsoft.AspNetCore.Mvc;
using FinanceHelper.Repository;
using FinanceHelper.Helper;

namespace FinanceHelper.Controllers {
	public class LoginController : Controller {

		private readonly IUserRepository _userRespository;
		private readonly IUserSession _userSession;

		public LoginController(IUserRepository userRespository, IUserSession userSession) {
			_userRespository = userRespository;
			_userSession = userSession;
		}

		public IActionResult Index() {

			//if the user is logged in, it must direct to home 
			if (_userSession.GetSessionUser() != null) return RedirectToAction("Index", "Home"); 

			return View();
		}

		public IActionResult CloseSession() {

			_userSession.RemoveSessionUser();

			return RedirectToAction("Index", "Login");
		}

		[HttpPost]
		public IActionResult Login(LoginModel loginModel) {
			try {
				if (ModelState.IsValid) {

					UserModel user = _userRespository.GetUserByLogin(loginModel.Login);

					if (user is not null) {

						if (user.PasswordIsValid(loginModel.Password)) {
							_userSession.CreateSessionUser(user);
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
