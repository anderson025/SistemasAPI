using System.ComponentModel.DataAnnotations;

namespace FinanceHelper.Models {
	public class RedefinePasswordModel {
		[Required(ErrorMessage = "Digite o Login.")]
		public string Login { get; set; }
		[Required(ErrorMessage = "Digite o e-mail.")]
		public string Email { get; set; }
	}
}
