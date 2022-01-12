using System;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public partial class User
    {
        public User()
        {
            StudentClasses = new HashSet<StudentClass>();
            TeacherClasses = new HashSet<TeacherClass>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public int StatusId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}
