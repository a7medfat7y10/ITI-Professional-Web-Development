using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    public class Employee
    {
        public Employee(int _EmployeeID, DateTime _BirthDate, int _VacationStock)
        {
            EmployeeID = _EmployeeID;
            BirthDate = _BirthDate;
            VacationStock = _VacationStock;
        }

        //event handler
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        protected virtual void OnEmployeeLayOff (EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }


        public int EmployeeID { get; set; }
        public DateTime BirthDate
        {
            get;
            set;
        }
        public int VacationStock
        {
            get; 
            set;
        }
        public bool RequestVacation(DateTime From, DateTime To)
        {
            int duration = To.Day - From.Day;
            if (VacationStock - duration >= 0)
            {
                VacationStock = VacationStock - duration;
                return true;
            }
            else
            {
                LayOffCause Cause = LayOffCause.Vacation_Limit;
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(Cause));
                return false;
            }
        }
        public void EndOfYearOperation()
        {
            int nextyear = DateTime.Now.Year;

            if (nextyear - this.BirthDate.Year >= 60)
            {
                LayOffCause Cause = LayOffCause.Retirement;
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(Cause));
            }
        }

        public override string ToString()
        {
            return EmployeeID.ToString();
        }
    }
    public enum LayOffCause
    {
        Vacation_Limit, Retirement, Sales_Target, Resignation
    }
    public class EmployeeLayOffEventArgs:EventArgs
    {
        public LayOffCause Cause { get; set; }
        public EmployeeLayOffEventArgs(LayOffCause C) {
            Cause = C;
        }
    }

    public class SalesPerson : Employee
    {
        public SalesPerson(int _EmployeeID, DateTime _BirthDate, int _VacationStock, int _AchievedTarget) : base(_EmployeeID, _BirthDate, _VacationStock)
        {
            AchievedTarget = _AchievedTarget;
        }

        public int AchievedTarget { get; set; }
        public bool CheckTarget(int Quota)
        {
            if (AchievedTarget >= Quota)
            {
                return true;
            }
            else
            {
                LayOffCause Cause = LayOffCause.Sales_Target;
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(Cause));
                return false;
            }            
        }
    }
    public class BoardMember : Employee
    {
        public BoardMember(int _EmployeeID, DateTime _BirthDate) : base(_EmployeeID, _BirthDate, 0)
        {

        }

        public void Resign()
        {
            LayOffCause Cause = LayOffCause.Resignation;
            OnEmployeeLayOff(new EmployeeLayOffEventArgs(Cause));
        }
    }
}
