using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class UserRole
    {
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public int LOOKUPRoleID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int RowCreatedUserID { get; set; }
        public Nullable<System.DateTime> RowCreatedDateTime { get; set; }
        public int RowModifiedUserID { get; set; }
        public Nullable<System.DateTime> RowModifiedDateTime { get; set; }

        public virtual LOOKUPRole LOOKUPRole { get; set; }
        public virtual User User { get; set; }
    }
}
