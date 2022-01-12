using System;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
