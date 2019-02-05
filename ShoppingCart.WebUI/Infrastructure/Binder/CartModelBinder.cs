using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.WebUI.Infrastructure.Binder
{
    // 1.dung binder co the tach rieng biet logic ra khoi controller(luc dau dung ham GetCart o Controller)
    // do do co the luu object Cart ma khong can thay doi Controller
    // 2.co the de dang dung parameter da binder(cart) tai cac action
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            // neu k co session Cart thi tao 1 Cart moi
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            return cart;
        }
    }
}