using ShoppingCart.Domain.Abtracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.WebUI.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;

        public BookController(IBookRepository repositoryParam)
        {
            repository = repositoryParam;
        }

        // GET: Book
        public ActionResult List()
        {
            return View(repository.Books);
        }
    }
}