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

		public IActionResult Update(int id) {

			UserModel user = _userRepository.GetById(id);
			return View(user);

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

		public IActionResult ConfirmDelete(int id) {
			UserModel user = _userRepository.GetById(id);
			return View(user);
		}

		public IActionResult Delete(int id) {

			try {

				bool deleted = _userRepository.Delete(id);
				if (deleted)
					TempData["SuccessMessage"] = "Usuário Deletado com sucesso.";
				else
					TempData["ErrorMessage"] = "Erro ao Deletar o usuário.";
				return RedirectToAction("Index");

			}
			catch (Exception error) {
				TempData["ErrorMessage"] = $"Erro ao Deletar o usuário:{error}";
				return RedirectToAction("Index");
			}

		}

		[HttpPost]
		public IActionResult Update(NoPasswordUserModel noPasswordUserModel) {
			try {
				UserModel user = null;
				if (ModelState.IsValid) {
					user = new UserModel() {
						Id = noPasswordUserModel.Id,
						Name = noPasswordUserModel.Name,
						Login = noPasswordUserModel.Email,
						Email = noPasswordUserModel.Email,
						Profile = noPasswordUserModel.Profile
					};

					user = _userRepository.Update(user);
					TempData["SuccessMessage"] = "Usuário atualizado com sucesso.";
					return RedirectToAction("Index");
				}

				return View(user);
			}
			catch (Exception error) {

				TempData["ErrorMessage"] = $"Erro ao atualizar usuário:{error}";
				return RedirectToAction("Index");
			}
		}
	}
}
