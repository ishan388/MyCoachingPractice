using System;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public partial class Status
    {
        public Status()
        {
            Users = new HashSet<User>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
