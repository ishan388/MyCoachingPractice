using System;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public partial class TeacherClass
    {
        public int Tcid { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual User Teacher { get; set; } = null!;
    }
}
