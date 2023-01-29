using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emp_struct
{
    struct Employee
    {
        int id;
        Security security_level;
        int salary;
        HiringDate hiredate;
        Gender gender;
        string name;

        //props
        public int Id { get { return id; } set { id = value; } }
        public Security Security_level { get { return security_level; } set { security_level = value; } }
        public int Salary { get { return salary; } set { salary = value; } }
        public HiringDate Hiredate { get { return hiredate; } set { hiredate = value; } }
        public Gender Gender { get { return gender; } set { gender = value; } }

        public string Name { get { return name; } set { name = value; } }


        //consturctor
        public Employee(int _id, Security _sl, int _s, HiringDate _d, Gender _g, string _name)
        {
            id = _id;
            security_level = _sl;
            salary = _s;
            hiredate = _d;
            gender = _g;
            name = _name;
        }


        #region getters and setters
        //public int GetID()
        //{
        //    return Id;
        //}
        //public Security GetSecurityLevel()
        //{
        //    return security_level;
        //}
        //public int GetSalary()
        //{
        //    return salary;
        //}
        //public HiringDate GetHiringDate()
        //{
        //    return hiredate;
        //}
        //public Gender GetGender()
        //{
        //    return gender;
        //}

        //public void SetID(int _id)
        //{
        //    Id = _id;
        //}
        //public void SetSecurityLevel(Security _sl)
        //{
        //    security_level = _sl;
        //}
        //public void SetSalary(int _s)
        //{
        //    salary = _s;
        //}
        //public void SetHiringDate(HiringDate _d)
        //{
        //    hiredate = _d;            
        //}
        //public void SetGender(Gender _g)
        //{
        //    gender = _g;   
        //}
        #endregion


        
        public override string ToString()
        {
            string emp_data =
                $"ID is {id},\n name is {name}\n" +
                $" his security level is {security_level},\n " +
                $"his salary is $ {string.Format("{0:#.00}", Convert.ToDecimal(salary))}, \n" +
                $" his gender is {gender}, \n" +
                $" and the hire date is {hiredate.ToString()}";
            return emp_data;
        }   
    }



    enum Gender
    {
        M, F
    }

    [Flags]
    enum Security
    {
        guest = 1, developer = 2, secretary = 4, DBA = 8, security_officer = 0b_0000_1111
    }
}
