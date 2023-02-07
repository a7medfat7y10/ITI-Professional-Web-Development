using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    public class Club
    {
        public Club(int _ClubID, string _ClubName)
        {
            ClubID = _ClubID;
            ClubName = _ClubName;
            Members = new List<Employee>();
        }
        public int ClubID { get; set; }
        public String ClubName { get; set; }

        List<Employee> Members;
        public void AddMember(Employee E)
        {
            Members.Add(E);
            E.EmployeeLayOff += RemoveMember;
        }
        ///CallBackMethod
        public void RemoveMember (object sender, EmployeeLayOffEventArgs e)
        {
            if ((sender is Employee emp) && (sender != null))
            {
                if (e.Cause == LayOffCause.Vacation_Limit)
                {
                    if (emp.GetType().Name == "Employee")
                    {
                        Members.Remove(emp);
                        Console.WriteLine($"Removing Employee: {emp} From club cuz of vacation limit\n");
                    }
                }
                else if (e.Cause == LayOffCause.Sales_Target)
                {
                    if (emp.GetType().Name == "SalesPerson")
                    {
                        Members.Remove(emp);
                        Console.WriteLine($"Removing Employee: {emp} from club cuz of sales target\n");
                    }
                }
                else if (e.Cause == LayOffCause.Resignation)
                {
                    if (emp.GetType().Name != "BoardMember")
                    {
                        Members.Remove(emp);
                        Console.WriteLine($"Removing Employee: {emp} from club as employee resined\n");
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder Club_Members = new StringBuilder();

            foreach (var employee in Members)
            {
                Club_Members.Append(employee.EmployeeID).Append(" - ");
            }

            return Club_Members.ToString();
        }

    }
}
