using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Abtracts
{
    public interface IAuthProvider
    {
        bool GetUserPassword(string loginName, string password);

        bool InUserRole(string loginName, string password);
    }
}
