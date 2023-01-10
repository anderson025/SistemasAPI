using FinanceHelper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace FinanceHelper.Filters {
	public class LoggedUserPage : ActionFilterAttribute{

		public override void OnActionExecuting(ActionExecutingContext context) {
			string userSession = context.HttpContext.Session.GetString("loggedUserSession");

			if (string.IsNullOrEmpty(userSession)) {

				context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });


			}
			else {
				UserModel userModel = JsonConvert.DeserializeObject<UserModel>(userSession);

				if (userModel == null) {
					context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
				}
			}

			base.OnActionExecuting(context);
		}
		
	}
}
