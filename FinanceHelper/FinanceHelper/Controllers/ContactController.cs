﻿using Microsoft.AspNetCore.Mvc;

namespace FinanceHelper.Controllers {
	public class ContactController : Controller {
		public IActionResult Index() {
			return View();
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
	}
}