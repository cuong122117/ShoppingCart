using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class UserProfile
    {
        public int UserProfileID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int RowCreatedUserID { get; set; }
        public Nullable<System.DateTime> RowCreatedDateTime { get; set; }
        public int RowModifiedUserID { get; set; }
        public Nullable<System.DateTime> RowModifiedDateTime { get; set; }

        public virtual User User { get; set; }
    }
}
