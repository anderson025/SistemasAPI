using FinanceHelper.Models;
using FinanceHelper.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHelper.Controllers {
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
			_contactRepository.Delete(id);
			return RedirectToAction("Index");
        }

		[HttpPost]
		public IActionResult Create(ContactModel contactModel) {

			try {

				if (ModelState.IsValid) {

					_contactRepository.Create(contactModel);
					TempData["SucessMessage"] = "Contato cadastrado com sucesso.";
					return RedirectToAction("Index");
				}

				return View(contactModel);
			}
			catch (Exception erro) {

				TempData["ErrorMessage"] = $"Erro ao cadastrar contato:{erro}";
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult Update(ContactModel contactModel) {

			_contactRepository.Update(contactModel);
			return RedirectToAction("Index");
		}
	}
}
