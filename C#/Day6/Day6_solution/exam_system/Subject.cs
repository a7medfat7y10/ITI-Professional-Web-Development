using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_system
{
    internal class Subject
    {
        public string Name { get; set; }
        public Question[] Subject_Questions { get; set; }
        public Subject(string _n, Question[] subject_Questions)
        {
            Name = _n;
            Subject_Questions = subject_Questions;
        }
    }
}
