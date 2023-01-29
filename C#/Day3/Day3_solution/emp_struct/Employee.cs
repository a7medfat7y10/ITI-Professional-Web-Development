using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emp_struct
{
    struct Employee
    {
        int Id;
        Security security_level;
        int salary;
        HiringDate hiredate;
        Gender gender;

        public Employee(int _id, Security _sl, int _s, HiringDate _d, Gender _g)
        {
            Id = _id;
            security_level = _sl;
            salary = _s;
            hiredate = _d;
            gender = _g;
        }

        #region getters and setters
        public int GetID()
        {
            return Id;
        }
        public Security GetSecurityLevel()
        {
            return security_level;
        }
        public int GetSalary()
        {
            return salary;
        }
        public HiringDate GetHiringDate()
        {
            return hiredate;
        }
        public Gender GetGender()
        {
            return gender;
        }

        public void SetID(int _id)
        {
            Id = _id;
        }
        public void SetSecurityLevel(Security _sl)
        {
            security_level = _sl;
        }
        public void SetSalary(int _s)
        {
            salary = _s;
        }
        public void SetHiringDate(HiringDate _d)
        {
            hiredate = _d;            
        }
        public void SetGender(Gender _g)
        {
            gender = _g;   
        }
        #endregion


        
        public override string ToString()
        {
            string emp_data =
                $"ID is {Id},\n his security level is {security_level},\n " +
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
