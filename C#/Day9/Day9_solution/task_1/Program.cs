namespace task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employees
            Employee    emp1    = new Employee      (1, new(1962, 12, 2), 3);
            Employee    emp2    = new Employee      (2, new(1975, 3, 5), 3);
            SalesPerson emp3    = new SalesPerson   (3, new(1980, 4, 12), 3, 9999);
            SalesPerson emp4    = new SalesPerson   (4, new(1980, 4, 12), 3, 10000);
            BoardMember emp5    = new BoardMember   (5, new(1970, 12, 2));
            BoardMember emp6    = new BoardMember   (6, new(1970, 12, 2));
            //department
            Department d1 = new Department(10, "SD");
            //club
            Club c1 = new Club(1, "c1");

            //adding the 6 employees to department and club
            d1.AddStaff(emp1);
            d1.AddStaff(emp2);
            d1.AddStaff(emp3);
            d1.AddStaff(emp4);
            d1.AddStaff(emp5);
            d1.AddStaff(emp6);
            c1.AddMember(emp1);
            c1.AddMember(emp2);
            c1.AddMember(emp3);
            c1.AddMember(emp4);
            c1.AddMember(emp5);
            c1.AddMember(emp6);


            Console.WriteLine("Department at the beginning: ");
            Console.WriteLine(d1.ToString());


            Console.WriteLine("Club at the beginning: ");
            Console.WriteLine(c1.ToString());

            emp1.EndOfYearOperation();
            emp2.EndOfYearOperation();
            emp3.EndOfYearOperation();
            emp4.EndOfYearOperation();
            emp5.EndOfYearOperation();
            emp6.EndOfYearOperation();

            Console.WriteLine("Department After the end of the year: ");
            Console.WriteLine(d1.ToString());

            Console.WriteLine("Club After the end of the year: ");
            Console.WriteLine(c1.ToString());

            emp2.RequestVacation(new DateTime(2020, 3, 3), new DateTime(2020, 3, 8));
            emp3.RequestVacation(new DateTime(2020, 3, 3), new DateTime(2020, 3, 8));
            emp4.RequestVacation(new DateTime(2020, 3, 3), new DateTime(2020, 3, 8));
            emp5.RequestVacation(new DateTime(2020, 3, 3), new DateTime(2020, 3, 8));
            emp6.RequestVacation(new DateTime(2020, 3, 3), new DateTime(2020, 3, 8));


            Console.WriteLine("Employees After passing vacation limit for all employees: ");
            Console.WriteLine(d1.ToString());


            Console.WriteLine("Club After passing vacation limit for all employees: ");
            Console.WriteLine(c1.ToString());


            emp3.CheckTarget(10000);
            emp4.CheckTarget(10000);


            Console.WriteLine($"Department After Target checking for for {emp3} & {emp4}: ");
            Console.WriteLine(d1.ToString());


            Console.WriteLine($"Club After Target checking for {emp3} & {emp4}: ");
            Console.WriteLine(c1.ToString());


            emp5.Resign();

            Console.WriteLine($"Department After Resgning {emp5}: ");
            Console.WriteLine(d1.ToString());

            Console.WriteLine($"Club After Resgning {emp5}: ");
            Console.WriteLine(c1.ToString());
        }
    }
}