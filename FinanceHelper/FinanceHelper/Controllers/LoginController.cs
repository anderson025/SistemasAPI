using FinanceHelper.Models;
using Microsoft.AspNetCore.Mvc;
using FinanceHelper.Repository;
using FinanceHelper.Helper;

namespace FinanceHelper.Controllers {
	public class LoginController : Controller {

		private readonly IUserRepository _userRespository;
		private readonly IUserSession _userSession;
		private readonly IEmail _email;

		public LoginController(IUserRepository userRespository, IUserSession userSession, IEmail email) {
			_userRespository = userRespository;
			_userSession = userSession;
			_email = email;
		}

		public IActionResult Index() {

			//if the user is logged in, it must direct to home 
			if (_userSession.GetSessionUser() != null) return RedirectToAction("Index", "Home");

			return View();
		}

		public IActionResult RedefinePassword() {
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

		[HttpPost]
		public IActionResult SendLinkForPasswordRedefinition(RedefinePasswordModel redefinePasswordModel) {
			try {
				if (ModelState.IsValid) {

					UserModel user = _userRespository.GetUserByEmailAndLogin(redefinePasswordModel.Email, redefinePasswordModel.Login);

					if (user is not null) {
						string newPassword = user.GenerateNewPassword();
						string subject = "Sistema de Contato - Nova senha";
						string message = $"Sua nova senha é {newPassword}";

						bool sentEmail = _email.SendEmail(user.Email, subject, message);

						if (sentEmail) {
							_userRespository.Update(user);
							TempData["SuccessMessage"] = $"Enviamos uma nova senha para seu e-mail cadastrado!";
						}
						else {
							TempData["ErrorMessage"] = "Não conseguimos enviar sua senha. Por favor, verifique os dados informados!";
						}
						
						return RedirectToAction("Index", "Login");
					}
					else {
						TempData["ErrorMessage"] = "Não conseguimos redefinir sua senha. Por favor, tente novamente!";
					}
				}
				return View("Index");
			}
			catch (Exception error) {

				TempData["ErrorMessage"] = $"Ops! Não foi possível redefinir sua senha. {error}";
				return RedirectToAction("Index");
			}
		}
	}
}
