using FinanceHelper.Models;

namespace FinanceHelper.Repository {
	public interface IContactRepository {

		ContactModel Create(ContactModel contact);
	}
}
