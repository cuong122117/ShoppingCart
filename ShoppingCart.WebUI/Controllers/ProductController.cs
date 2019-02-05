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
    public class ProductController : Controller
    {
        private IProductRepository repository;

        private int PageSize = 4;                   //muon hien thi 4san pham cho moi trang

        // tao 1 constructor dependency vao interface IProductRepository
        public ProductController(IProductRepository repositoryParam)
        {
            // khi instance duoc khoi tao no se inject dependency
            repository = repositoryParam;
        }

        // hien thi List cac san pham
        // voi cac method k co argument thi se hien thi List(1)
        // bo qua nhung san pham truoc trang se hien thi
        // moi trang chi hien thi 4san pham
        // them parameter category de co the chon theo category
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel {
                Products = repository.Products
                                    .Where(p => p.Category == category || category == null) //neu category=null thi se hien thi tat ca
                                    .OrderBy(p => p.ProductID)
                                    .Skip((page - 1) * PageSize)
                                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    TotalItems = category == null ? 
                                repository.Products.Count() : repository.Products.Where(p => p.Category == category).Count(),
                    CurrentPage = page,
                    ItemsPerPage = PageSize
                    },
                CurrentCategory = category
            };


            return View(model);
        }

        // FileContentResult duoc su dung khi muon lay file tu client browser ve
        // su dung instance File() co ban cua controller
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products
                                     .FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}