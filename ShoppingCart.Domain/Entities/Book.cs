using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Featured { get; set; }
    }
}
