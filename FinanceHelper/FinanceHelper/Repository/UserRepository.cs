using FinanceHelper.Data;
using FinanceHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceHelper.Repository {
	public class UserRepository : IUserRepository {

		private readonly DataBaseContext _dataBaseContext;

		public UserRepository(DataBaseContext dataBaseContext) {

			_dataBaseContext = dataBaseContext;
		}

		public UserModel GetUserByLogin(string login) {
			return _dataBaseContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
		}

		public UserModel GetUserByEmailAndLogin(string email, string login) {
			return _dataBaseContext.Users.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
		}

		public UserModel GetById(int id) {
			return _dataBaseContext.Users.FirstOrDefault(user => user.Id == id);
		}

		public List<UserModel> SelectAll() {

			return _dataBaseContext.Users
				.Include(x => x.Contacts)
				.ToList();
		}
		public UserModel Create(UserModel user) {

			user.RegistrationDate = DateTime.Now;
			user.SetPasswordHash();
			_dataBaseContext.Users.Add(user);
			_dataBaseContext.SaveChanges();
			return user;
		}

		public UserModel Update(UserModel user) {
			UserModel contactDB = GetById(user.Id);

			if (contactDB == null)
				throw new Exception("Houve um erro na atualização do contato.");
			contactDB.Name = user.Name;
			contactDB.Email = user.Email;
			contactDB.Login = user.Login;
			contactDB.UpdateDate = DateTime.Now;
			contactDB.Profile = user.Profile;			


			_dataBaseContext.Users.Update(contactDB);
			_dataBaseContext.SaveChanges();

			return contactDB;
		}

		public bool Delete(int id) {
			UserModel contactDB = GetById(id);

			if (contactDB == null)
				throw new Exception("Houve um erro da deleção do contato!");

			_dataBaseContext.Users.Remove(contactDB);
			_dataBaseContext.SaveChanges();

			return true;
		}

		public UserModel UpdatePassword(ChangePasswordModel changePasswordModel) {
			UserModel contactDB = GetById(changePasswordModel.Id);

			if (contactDB == null) throw new Exception("Houve um erro na Atualização da senha.");

			if (!contactDB.PasswordIsValid(changePasswordModel.CurrentPassword)) throw new Exception("Senha Atual não confere!");

			if (contactDB.PasswordIsValid(changePasswordModel.NewPassword)) throw new Exception("Nova senha deve ser diferente da senha Atual!");

			contactDB.SetNewPassword(changePasswordModel.NewPassword);
			contactDB.UpdateDate= DateTime.Now;

			_dataBaseContext.Users.Update(contactDB);

			_dataBaseContext.SaveChanges();

			return contactDB;
		}
	}
}
