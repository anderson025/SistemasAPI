using FinanceHelper.Models;

namespace FinanceHelper.Repository {
	public interface IContactRepository {

		List<ContactModel> SelectAll();

		ContactModel Create(ContactModel contact);
	}
}
