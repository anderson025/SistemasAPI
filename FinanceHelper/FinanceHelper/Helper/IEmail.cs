﻿namespace FinanceHelper.Helper {
	public interface IEmail {

		bool SendEmail(string email, string subject, string message);
	}
}
