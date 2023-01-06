using FinanceHelper.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceHelper.Models {
	public class UserModel {

		public int Id { get; set; }

		[Required(ErrorMessage = "Digite o Nome do usuário.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Digite o login do usuário.")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Digite o Email do contato.")]
		[EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
		public string Email { get; set; }

		public ProfileEnum Profile { get; set; }

		[Required(ErrorMessage = "Digite a senha do usuário.")]

		public string Password { get; set; }

		public DateTime RegistrationDate { get; set; }

		public DateTime? UpdateDate { get; set; }


	}
}
