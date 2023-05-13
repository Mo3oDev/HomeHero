using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace HomeHero.Filters
{
    public class AuthorizeUsersAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            }
            else if (!string.IsNullOrEmpty(Roles))
            {
                if (!user.IsInRole(Roles))
                {
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
            }
        }
    }
}
