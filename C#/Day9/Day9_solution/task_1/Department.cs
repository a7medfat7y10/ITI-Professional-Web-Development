using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    public class Department
    {
        public Department(int _DeptID, string _DeptName)
        {
            DeptID = _DeptID;
            DeptName = _DeptName;
            Staff = new List<Employee>();
        }
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> Staff;
        public void AddStaff(Employee E)
        {
            Staff.Add(E);
            E.EmployeeLayOff += this.RemoveStaff;
        }
        ///CallBackMethod
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if ((sender is Employee emp) && (sender != null))
            {
                if (e.Cause == LayOffCause.Vacation_Limit)
                {
                    if (emp.GetType().Name == "Employee")
                    {
                        Staff.Remove(emp);
                        Console.WriteLine($"Layoff Employee: {emp} because of vacation limit\n");
                    }
                }
                else if (e.Cause == LayOffCause.Sales_Target)
                {
                    if (emp.GetType().Name == "SalesPerson")
                    {
                        Staff.Remove(emp);
                        Console.WriteLine($"Layoff Employee: {emp} because of sales target\n");
                    }
                }
                else if (e.Cause == LayOffCause.Retirement)
                {
                    if (emp.GetType().Name != "BoardMember")
                    {
                        Staff.Remove(emp);
                        Console.WriteLine($"Layoff Employee: {emp} because of retirement\n");
                    }
                }
                else
                {
                    Staff.Remove(emp);
                    Console.WriteLine($"Employee: {emp} Resigned\n ");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder Employees_Staff = new StringBuilder();

            foreach (var employee in Staff)
            {
                Employees_Staff.Append(employee.EmployeeID).Append(" - ");
            }

            return Employees_Staff.ToString();
        }
    }
}
