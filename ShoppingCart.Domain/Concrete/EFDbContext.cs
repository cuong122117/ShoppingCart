using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<LOOKUPRole> LOOKUPRole { get; set; }

        //public System.Data.Entity.DbSet<ShoppingCart.WebUI.Models.LoginViewModel> LoginViewModels { get; set; }

        //public System.Data.Entity.DbSet<ShoppingCart.WebUI.Models.UserSignUpView> UserSignUpViews { get; set; }
    }
}
