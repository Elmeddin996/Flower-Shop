using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Flowers.UI.Filters
{
    public class AuthFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Cookies["auth_token"] == null)
            {
                context.Result = new RedirectResult("/account/login");
                return;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
