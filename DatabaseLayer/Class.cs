using System;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public partial class Class
    {
        public Class()
        {
            StudentClasses = new HashSet<StudentClass>();
            TeacherClasses = new HashSet<TeacherClass>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual ICollection<StudentClass> StudentClasses { get; set; }
        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}
