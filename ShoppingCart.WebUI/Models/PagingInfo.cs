using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.WebUI.Models
{
    // tao 1 modelView de truyen cac thong so cua trang giup cho HtmlHelper
    // 1 View model khong phai la 1 thanh phan cua domain model nhung no chua cac thong tin truyen giua controller va view
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}