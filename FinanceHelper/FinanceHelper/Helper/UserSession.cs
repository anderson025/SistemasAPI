using FinanceHelper.Models;
using Newtonsoft.Json;

namespace FinanceHelper.Helper {
	public class UserSession : IUserSession {

		private readonly IHttpContextAccessor _httpContext;

		public UserSession(IHttpContextAccessor httpContext) {
			_httpContext = httpContext;
		}

		public void CreateSessionUser(UserModel user) {

			string userSession = JsonConvert.SerializeObject(user);
			_httpContext.HttpContext.Session.SetString("loggedUserSession", userSession);
		}

		public UserModel GetSessionUser() {

			string userSession = _httpContext.HttpContext.Session.GetString("loggedUserSession");

			if (string.IsNullOrEmpty(userSession)) return null;

			return JsonConvert.DeserializeObject<UserModel>(userSession);

		}
		public void RemoveSessionUser() {
			_httpContext.HttpContext.Session.Remove("loggedUserSession");
		}
	}
}
