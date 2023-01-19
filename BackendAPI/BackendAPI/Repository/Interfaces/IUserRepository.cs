

using BackendAPI.Models;

namespace BackendAPI.Interfaces.Repository {
	public interface IUserRepository {

		Task<UserModel> GetUserByLogin(string Login);
		Task<UserModel> GetUserByEmailAndLogin(string Email, string Login);
		Task<UserModel> GetById(int id);
		Task<List<UserModel>> SelectAll();
		Task<UserModel> Create(UserModel user);
		Task<UserModel> Update(UserModel user, int id);
		//Task<UserModel> UpdatePassword(ChangePasswordModel changePasswordModel);
		Task<bool> Delete(int id);
	}
}
