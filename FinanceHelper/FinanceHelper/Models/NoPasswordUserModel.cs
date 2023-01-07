using FinanceHelper.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceHelper.Models {
	public class NoPasswordUserModel {

		public int Id { get; set; }

		[Required(ErrorMessage = "Digite o Nome do usuário.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Digite o login do usuário.")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Digite o Email do contato.")]
		[EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Selecione o perfil do usuário.")]
		public ProfileEnum? Profile { get; set; }

	}
}
