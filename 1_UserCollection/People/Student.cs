using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCollections_1
{
    internal class Student : Civilian
    {
        public override string Occupation { get; } = "Student";
        public Student(int passportID) : base(passportID) { }
    }
}
