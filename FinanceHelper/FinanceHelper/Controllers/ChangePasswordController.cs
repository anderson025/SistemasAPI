using FinanceHelper.Helper;
using FinanceHelper.Models;
using FinanceHelper.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHelper.Controllers {
	public class ChangePasswordController : Controller {

		private readonly IUserRepository _userRepository;
		private readonly IUserSession _session;

		public ChangePasswordController(IUserRepository userRepository, IUserSession session) {
			_userRepository = userRepository;
			_session = session;
		}

		public IActionResult Index() {
			return View();
		}

		[HttpPost]
		public IActionResult GenerateNewPassword(ChangePasswordModel changePasswordModel) {

			try {
				UserModel loggedUser = _session.GetSessionUser();
				changePasswordModel.Id = loggedUser.Id;

				if (ModelState.IsValid) {

					_userRepository.UpdatePassword(changePasswordModel);
					TempData["SuccessMessage"] = "Senha atualizado com sucesso.";
					return View("Index", changePasswordModel);
				}

				return View("Index", changePasswordModel);
			}
			catch (Exception error) {

				TempData["ErrorMessage"] = $"Erro ao Atualizar a senha:{error.Message}";
				return View("Index", changePasswordModel);
			}
			
		}
	}
}
