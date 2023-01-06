using FinanceHelper.Models;
using FinanceHelper.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHelper.Controllers {
	public class UserController : Controller {

		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository) {
			_userRepository = userRepository;
		}

		public IActionResult Index() {
			List<UserModel> contacts = _userRepository.SelectAll();
			return View(contacts);
		}

		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public IActionResult Create(UserModel userModel) {

			try {

				if (ModelState.IsValid) {

					_userRepository.Create(userModel);
					TempData["SuccessMessage"] = "Usuário cadastrado com sucesso.";
					return RedirectToAction("Index");
				}

				return View(userModel);
			}
			catch (Exception error) {

				TempData["ErrorMessage"] = $"Erro ao cadastrar usuário:{error}";
				return RedirectToAction("Index");
			}
		}
	}
}
