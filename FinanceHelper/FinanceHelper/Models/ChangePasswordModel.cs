using System.ComponentModel.DataAnnotations;

namespace FinanceHelper.Models {
	public class ChangePasswordModel {

		public int Id { get; set; }

		[Required(ErrorMessage = "Digite a senha atual do usuário.")]
		public String CurrentPassword { get; set; }

		[Required(ErrorMessage = "Digite a nova senha do usuário.")]
		public String NewPassword { get; set; }

		[Required(ErrorMessage = "Confirme a nova senha do usuário.")]
		[Compare("NewPassword", ErrorMessage ="Senha não confere com a nova senha.")]
		public String ConfirmNewPassword { get; set; }
	}
}
