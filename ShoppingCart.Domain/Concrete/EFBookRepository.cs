using ShoppingCart.Domain.Abtracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Domain.Concrete
{
    public class EFBookRepository : IBookRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get
            {
                return context.Books;
            }
        }
    }
}
