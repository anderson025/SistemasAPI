using FinanceHelper.Data;
using FinanceHelper.Models;

namespace FinanceHelper.Repository {
	public class ContactRepository : IContactRepository {

		private readonly DataBaseContext _dataBaseContext;

		public ContactRepository(DataBaseContext dataBaseContext) {

			_dataBaseContext = dataBaseContext;
		}


		public List<ContactModel> SelectAll() {

			return _dataBaseContext.Contacts.ToList();
		}
		public ContactModel Create(ContactModel contact) {

			_dataBaseContext.Contacts.Add(contact);
			_dataBaseContext.SaveChanges();
			return contact;
		}
		
	}
}
