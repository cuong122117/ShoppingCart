using ShoppingCart.Domain.Abtracts;
using ShoppingCart.Domain.Entities;
using ShoppingCart.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IProductRepository repositoryParam, IOrderProcessor proc)
        {
            repository = repositoryParam;
            orderProcessor = proc;
        }

        // 
        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }


        // RedirectToRouteResult dung de goi 1 HTTP request toi Client Browser, chi dan den 1 new URL
        // trong truong hop nay la noi Browser goi Index method cua CartController
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                                        .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        // khi MVC Framework nhan 1 request no se di tim cac parameter cua Action
        // no se tim cac binders co san va co gang tao 1 instance cho moi parameter(truong hop nay la binders dang ki o Global.asax)
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                                        .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        // co vai tro la 1 wiget hien thi o tat ca man hinh
        // user luon nhin thay wiget nay
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        // action xu li khi user click Checkout button
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails objShippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, objShippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(objShippingDetails);
            }
        }

        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }

        //    return cart;
        //}
    }
}