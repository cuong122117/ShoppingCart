using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Abtracts
{
    public interface IProductRepository
    {
        // IEnumerable<T> gom tap hop cac object Product ma khong can biet noi data duoc luu tru
        // 1 Class phu thuoc vao IProductRepository co the lay duoc tap hop cac product 
        //                                          ma khong can biet chung den tu dau
        //                                          va class nao da implement no 
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}
