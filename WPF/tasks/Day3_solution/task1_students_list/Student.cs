using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_students_list
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public Student(int _id, string _name, int _age, int _grade, string _address, string _image) {
            Id = _id;
            Name = _name;
            Age = _age;
            Grade = _grade;
            Address = _address;
            Image = _image;
        }
        public override string ToString()
        {
            return $"{Name}" ;
        }
    }
}
