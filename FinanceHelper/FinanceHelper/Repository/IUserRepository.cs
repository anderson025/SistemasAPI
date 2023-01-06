using FinanceHelper.Models;

namespace FinanceHelper.Repository {
	public interface IUserRepository {
		UserModel GetById(int id);
		List<UserModel> SelectAll();
		UserModel Create(UserModel user);
		UserModel Update(UserModel user);
		bool Delete(int id);
	}
}
