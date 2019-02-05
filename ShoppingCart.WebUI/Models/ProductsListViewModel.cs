using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.WebUI.Models
{
    // co the su dung ViewBag 
    // nhung vi muon tong hop tat cac data goi tu Controller toi View nen tao ra class nay
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}