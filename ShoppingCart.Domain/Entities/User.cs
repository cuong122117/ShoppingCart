using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string PasswordEncryptedText { get; set; }
        public int RowCreatedSYSUserID { get; set; }
        public Nullable<System.DateTime> RowCreatedDateTime { get; set; }
        public int RowModifiedSYSUserID { get; set; }
        public Nullable<System.DateTime> RowModifiedDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
