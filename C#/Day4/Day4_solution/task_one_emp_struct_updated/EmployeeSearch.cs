using emp_struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_one_emp_struct_updated
{
    internal class EmployeeSearch
    {
        int[] nationalids;
        Employee[] employees;
        string[] names;

        public EmployeeSearch(Employee[] _emps)
        {
            employees= _emps;
        }

        public int[] NationalIDs
        {
            get { return nationalids; }
            set { nationalids = value; }
        }
        public Employee[] Employees
        {
            get { return employees; }
            set { employees = value; }
        }
        public string[] Names
        {
            get { return names; }
            set { names = value; }
        }

        public Employee this[int id] 
        {
            get { 
                for(int i=0; i<employees.Length; i++)
                {
                    if (employees[i].Id == id)
                    {
                        return employees[i];
                    }
                }
                return new Employee();
            }
        }

        public Employee this[string name]
        {
            get
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i].Name == name)
                    {
                        return employees[i];
                    }
                }
                return new Employee();
            }
        }

        public Employee this[HiringDate date]
        {
            get
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i].Hiredate.ToString() == date.ToString())
                    {
                        return employees[i];
                    }
                }
                return new Employee();
            }
        }
    }
}
