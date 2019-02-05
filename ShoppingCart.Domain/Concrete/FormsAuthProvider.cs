using ShoppingCart.Domain.Abtracts;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private EFDbContext context = new EFDbContext();

        //private IUserRepository reposity
        public bool GetUserPassword(string loginName, string password)
        {

            var userValid = context.Users.Any(user => user.LoginName == loginName && user.PasswordEncryptedText == password);
            
            return userValid;
        }

        // check co truong tuong ung trong bang dbo.User hay k
        // neu co lay Role tuong ung
        public bool InUserRole(string loginName, string roleName)
        {
                var user = context.Users.Where(o => o.LoginName.ToLower().Equals(loginName))?.FirstOrDefault();
                if (user != null)
                {
                    var roles = from q in context.UserRoles join r in context.LOOKUPRole on q.LOOKUPRoleID equals r.LOOKUPRoleID
                                where r.RoleName.Equals(roleName) && q.UserID.Equals(user.UserID)
                                select r.RoleName;
                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }
        return false;
        }
    }
}
