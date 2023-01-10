using FinanceHelper.Models;

namespace FinanceHelper.Helper {
	public interface IUserSession {

		void CreateSessionUser(UserModel user);
		void RemoveSessionUser();
		UserModel GetSessionUser();
	}
}
