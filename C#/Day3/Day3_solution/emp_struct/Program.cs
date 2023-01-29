namespace emp_struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Employees Number");
            int n = int.Parse(Console.ReadLine());

            Employee[] EmpArr = new Employee[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Emp no {0} : ", i+1);

                int id;
                Security security_level;
                int salary;
                int day;
                string month;
                int year;
                Gender gender;

                Console.WriteLine("id");
                id = int.Parse(Console.ReadLine());

                Console.WriteLine("security level: ");
                security_level = (Security)Enum.Parse(typeof(Security), Console.ReadLine());

                Console.WriteLine("salary: ");
                salary = int.Parse(Console.ReadLine());

                Console.WriteLine("day: ");
                day = int.Parse(Console.ReadLine());

                Console.WriteLine("month: ");
                month = Console.ReadLine();

                Console.WriteLine("year: ");
                year = int.Parse(Console.ReadLine());

                Console.WriteLine("gender: ");
                gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());
                

                HiringDate date1 = new HiringDate(day, month, year);

                EmpArr[i] = new Employee(id, security_level, salary, date1, gender);

                Console.Write("\n");
            }

            for(int i = 0; i < n; i++)
            {
                Console.Write(EmpArr[i].ToString());
                Console.Write("\n");
            }
            
        }
    }
}