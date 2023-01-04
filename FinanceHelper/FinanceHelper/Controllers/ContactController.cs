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
		public IActionResult Update() {
			return View();
		}
		public IActionResult ConfirmDelete() {
			return View();
		}

		[HttpPost]
		public IActionResult Create(ContactModel contactModel) {

			_contactRepository.Create(contactModel);
			return RedirectToAction("Index");
		}
	}
}
