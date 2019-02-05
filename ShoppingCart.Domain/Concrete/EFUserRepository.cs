using ShoppingCart.Domain.Abtracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        
        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }
    }
}
