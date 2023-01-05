﻿using FinanceHelper.Models;

namespace FinanceHelper.Repository {
	public interface IContactRepository {
		ContactModel GetById(int id);
		List<ContactModel> SelectAll();

		ContactModel Create(ContactModel contact);
		ContactModel Update(ContactModel contact);
		bool Delete(int id);
	}
}
