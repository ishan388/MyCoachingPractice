using System;
using System.Collections.Generic;

namespace DatabaseLayer
{
    public partial class StudentClass
    {
        public int Scid { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual User Student { get; set; } = null!;
    }
}
