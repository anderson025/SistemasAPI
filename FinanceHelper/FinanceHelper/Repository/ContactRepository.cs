using FinanceHelper.Data;
using FinanceHelper.Models;

namespace FinanceHelper.Repository {
	public class ContactRepository : IContactRepository {

		private readonly DataBaseContext _dataBaseContext;

		public ContactRepository(DataBaseContext dataBaseContext) {

			_dataBaseContext = dataBaseContext;
		}

		public ContactModel GetById(int id) {
			return _dataBaseContext.Contacts.FirstOrDefault(contact => contact.Id == id);
		}

		public List<ContactModel> SelectAll(int userId) {

			return _dataBaseContext.Contacts.Where(user => user.Id == userId).ToList();
		}
		public ContactModel Create(ContactModel contact) {

			_dataBaseContext.Contacts.Add(contact);
			_dataBaseContext.SaveChanges();
			return contact;
		}

        public ContactModel Update(ContactModel contact) {
            ContactModel contactDB = GetById(contact.Id);

			if (contactDB == null)
				throw new Exception("Houve um erro na atualização do contato.");
			contactDB.Name = contact.Name;
			contactDB.Email = contact.Email;
			contactDB.Phone = contact.Phone;

			_dataBaseContext.Contacts.Update(contactDB);
			_dataBaseContext.SaveChanges();

			return contactDB;
        }

		public bool Delete(int id) {
			ContactModel contactDB = GetById(id);

			if (contactDB == null)
				throw new Exception("Houve um erro da deleção do contato!");

			_dataBaseContext.Contacts.Remove(contactDB);
			_dataBaseContext.SaveChanges();

			return true;
		}
    }
}
