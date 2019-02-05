using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Domain.Concrete
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRoles;
        public AuthorizeRolesAttribute(params string[] roles)
        {
            this.userAssignedRoles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            FormsAuthProvider objFormAuth = new FormsAuthProvider();
                foreach (var roles in userAssignedRoles)
                {
                    authorize = objFormAuth.InUserRole(httpContext.User.Identity.Name, roles);
                    if (authorize)
                        return authorize;
                }
            
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Admin/CheckRole");
        }
    }
}

