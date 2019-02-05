using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart.WebUI.Models
{
    public class LoginViewModel
    {
        [Key]
        public int SYSUserID { get; set; }
        [Required(ErrorMessage = "Vui long nhap ten dang nhap")]
        [Display(Name = "Login ID")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "Vui long nhap password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}