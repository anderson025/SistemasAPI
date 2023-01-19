using BackendAPI.Data;
using BackendAPI.Interfaces.Repository;
using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Repository {
	public class UserRepository : IUserRepository {

		private readonly FinanceAPIContext _financeAPIContext;

		public UserRepository(FinanceAPIContext financeAPIContext) {
			_financeAPIContext = financeAPIContext;
		}

		public async Task<UserModel> Create(UserModel user) {
			_financeAPIContext.Users.Add(user);
			_financeAPIContext.SaveChangesAsync();

			return user;
		}

		public async Task<bool> Delete(int id) {

			UserModel userModel = await GetById(id);

			if (userModel == null) {

				throw new Exception($"Usuário Id: {id} não encontrado");
			}

			_financeAPIContext.Users.Remove(userModel);
			_financeAPIContext.SaveChangesAsync();

			return true;
		}

		public async Task<UserModel> GetById(int id) {
			return await _financeAPIContext.Users.FirstOrDefaultAsync(x => x.Id == id);
		}

		public Task<UserModel> GetUserByEmailAndLogin(string Email, string Login) {
			throw new NotImplementedException();
		}

		public Task<UserModel> GetUserByLogin(string Login) {
			throw new NotImplementedException();
		}

		public async Task<List<UserModel>> SelectAll() {
			return await _financeAPIContext.Users.ToListAsync();
		}

		public async Task<UserModel> Update(UserModel user, int id) {

			UserModel userModel = await GetById(id);

			if (userModel == null) {

				throw new Exception($"Usuário Id: {id} não encontrado");
			}

			_financeAPIContext.Users.Update(userModel);
			_financeAPIContext.SaveChangesAsync();

			return userModel;
		}
	}
}
