using ShoppingCart.Domain.Abtracts;
using ShoppingCart.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShoppingCart.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                bool userValid = authProvider.GetUserPassword(model.LoginName, model.Password);
                if (!userValid)
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                        FormsAuthentication.SetAuthCookie(model.LoginName, false);
                        return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
            }
            // If we got this far, something failed, redisplay form return View(ULV); }
            return View(model);

        }

        [Authorize]
        public ActionResult SignOut() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }
    }
}