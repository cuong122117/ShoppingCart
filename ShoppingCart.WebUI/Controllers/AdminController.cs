using ShoppingCart.Domain.Abtracts;
using ShoppingCart.Domain.Concrete;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index(bool chk = true)
        {
            return View(repository.Products);
        }

        public ActionResult CheckRole()
        {
            TempData["checkRole"] = string.Format("Ban khong co quyen Edit san pham");
            return View("Index",repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
                                        .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        [AuthorizeRoles("Admin")]
        // su dung ActionResult de RedirectToAction
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                // khong the su dung ViewBag vi Redirect , no khong giu duoc data lau bang HttpRequest
                // TempData se bi xoa end HttpRequest
                // Con dung Session thi no giu data qua lau, can phai co method xoa cho no
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // xu ly khi validation sai
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AuthorizeRoles("Admin")]
        public ActionResult DeleteAjax(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

    }
}