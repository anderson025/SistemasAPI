using FinanceHelper.Filters;
using FinanceHelper.Models;
using FinanceHelper.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHelper.Controllers {

	[LoggedUserPage]
	public class ContactController : Controller {

		private readonly IContactRepository _contactRepository;

		public ContactController(IContactRepository contactRepository) {
			_contactRepository = contactRepository;
		}
		public IActionResult Index() {
			List<ContactModel> contacts = _contactRepository.SelectAll();
			return View(contacts);
		}
		public IActionResult Create() {
			return View();
		}
		public IActionResult Update(int id) {

			ContactModel contact = _contactRepository.GetById(id);
			return View(contact);

		}
		public IActionResult ConfirmDelete(int id) {
			ContactModel contact = _contactRepository.GetById(id);
			return View(contact);
		}

		public IActionResult Delete(int id) {

			try {

				bool deleted = _contactRepository.Delete(id);
				if (deleted) {

					TempData["SuccessMessage"] = "Contato Deletado com sucesso.";
				}
				else {
					TempData["ErrorMessage"] = "Erro ao Deletar o contato.";
				}

				return RedirectToAction("Index");

			}
			catch (Exception error) {

				TempData["ErrorMessage"] = $"Erro ao Deletar o contato:{error}";
				return RedirectToAction("Index");
			}

		}

		[HttpPost]
		public IActionResult Create(ContactModel contactModel) {

			try {

				if (ModelState.IsValid) {

					_contactRepository.Create(contactModel);
					TempData["SuccessMessage"] = "Contato cadastrado com sucesso.";
					return RedirectToAction("Index");
				}

				return View(contactModel);
			}
			catch (Exception error) {

				TempData["ErrorMessage"] = $"Erro ao cadastrar contato:{error}";
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult Update(ContactModel contactModel) {

			try {
				if (ModelState.IsValid) {
					_contactRepository.Update(contactModel);
					TempData["SuccessMessage"] = "Contato Atualizado com sucesso.";
					return RedirectToAction("Index");
				}

				return View(contactModel);
			}
			catch (Exception error) {

				TempData["ErrorMessage"] = $"Erro ao Atualizar o contato:{error}";
				return RedirectToAction("Index");
			}


		}
	}
}
