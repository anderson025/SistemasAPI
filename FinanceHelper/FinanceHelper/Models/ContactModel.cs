using System.ComponentModel.DataAnnotations;

namespace FinanceHelper.Models {
	public class ContactModel {

		public int Id { get; set; }

		[Required(ErrorMessage ="Digite o Nome do contato.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Digite o Email do contato.")]
		[EmailAddress(ErrorMessage ="O e-mail informado é inválido.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Digite o Telefone do contato.")]
		[Phone(ErrorMessage ="O telefone informado é inválido.")]
		public string Phone { get; set; }

		public int? UserId { get; set; }

		public UserModel User { get; set; }
	}
}
