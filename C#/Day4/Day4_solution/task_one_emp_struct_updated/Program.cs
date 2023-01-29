using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using task_one_emp_struct_updated;
using System;

namespace emp_struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region using props instead of getters and setters
            //Employee emp1 =  new Employee(1, Security.guest, 10000, new HiringDate(1, "1", 2022), Gender.M, "ahmed");
            ////setting 
            //emp1.Salary = 200;
            //emp1.Id= 3;
            //emp1.Gender = Gender.F;
            //emp1.Security_level = Security.DBA;
            ////getting
            //Console.WriteLine(emp1.Hiredate);
            //Console.WriteLine(emp1.Gender);
            //Console.WriteLine(emp1.Salary);
            //Console.WriteLine(emp1.Id);
            //Console.WriteLine(emp1.Security_level);
            #endregion


            Console.WriteLine("Enter the Employees Number");
            int n = int.Parse(Console.ReadLine());

            Employee[] EmpArr = new Employee[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Emp no {0} : ", i+1);

                int id;
                string name;
                Security security_level;
                int salary;
                int day;
                string month;
                int year;
                Gender gender;

                do
                {
                    Console.WriteLine("id");
                } while (!int.TryParse(Console.ReadLine(), out id));

                Console.WriteLine("Name: ");
                name = Console.ReadLine();

                do
                {
                    Console.WriteLine("security level: ");
                } while (!Enum.TryParse(Console.ReadLine(), out security_level));

                do
                {
                    Console.WriteLine("salary: ");
                } while (!int.TryParse(Console.ReadLine(), out salary));

                Console.WriteLine("Enter Hire Date: ");
                do
                {
                    Console.WriteLine("day: ");
                } while (!int.TryParse(Console.ReadLine(), out day));

                Console.WriteLine("month: ");
                month = Console.ReadLine();

                do
                {
                    Console.WriteLine("year: ");
                } while (!int.TryParse(Console.ReadLine(), out year));

                do
                {
                    Console.WriteLine("gender: ");
                } while (!Enum.TryParse(Console.ReadLine(), out gender));

                HiringDate date1 = new HiringDate(day, month, year);

                EmpArr[i] = new Employee(id, security_level, salary, date1, gender, name);

                Console.Write("\n");
            }

            for(int i = 0; i < n; i++)
            {
                Console.Write(EmpArr[i].ToString());
                Console.Write("\n");
            }

            #region indexer search emps
            Console.WriteLine("Search for Employee");
            Console.WriteLine("1.Search by id \n" +
                            "2.search by name\n" +
                            "3.search by date");
            
            int c;
            do
            {
                Console.WriteLine("Choose an option:");
            } while (!int.TryParse(Console.ReadLine(), out c));

            EmployeeSearch emp_search = new EmployeeSearch(EmpArr);

            switch (c)
            {
                case 1:
                    int n_id;
                    do
                    {
                        Console.WriteLine("Enter the employee id: ");
                    } while (!int.TryParse(Console.ReadLine(), out n_id));
                    Console.WriteLine(emp_search[n_id]);
                break;
                case 2:
                    Console.WriteLine("Enter the employee name: ");
                    string emp_name = Console.ReadLine();
                    Console.WriteLine(emp_search[emp_name]);
                break;
                case 3:
                    Console.WriteLine("Enter the employee hire date: ");
                    int h_day;
                    do
                    {
                        Console.WriteLine("day: ");
                    } while (!int.TryParse(Console.ReadLine(), out h_day));

                    Console.WriteLine("month: ");
                    string h_month = Console.ReadLine();

                    int h_year;
                    do
                    {
                        Console.WriteLine("year: ");
                    } while (!int.TryParse(Console.ReadLine(), out h_year));

                    HiringDate h_date = new HiringDate(h_day, h_month, h_year);
                    Console.WriteLine(emp_search[h_date]);
                break;

            }
            #endregion

        }
    }
}