namespace task_one_day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point3D P = new Point3D(10, 10, 10);
            Console.WriteLine(P.ToString());

            //string casting
            string p = (string) new Point3D(3, 4, 5);
            Console.WriteLine(p);


            //read two points from the user
            int x1;
            do{
                Console.WriteLine("Enter x1");
            } while (!int.TryParse(Console.ReadLine(), out x1));
            int y1;
            do
            {
                Console.WriteLine("Enter y1");
            } while (!int.TryParse(Console.ReadLine(), out y1));
            int z1;
            do
            {
                Console.WriteLine("Enter z1");
            } while (!int.TryParse(Console.ReadLine(), out z1));
            int x2;
            do
            {
                Console.WriteLine("Enter x2");
            } while (!int.TryParse(Console.ReadLine(), out x2));
            int y2;
            do
            {
                Console.WriteLine("Enter y2");
            } while (!int.TryParse(Console.ReadLine(), out y2));
            int z2;
            do
            {
                Console.WriteLine("Enter z2");
            } while (!int.TryParse(Console.ReadLine(), out z2));

            //bool flag = true;
            //do
            //{
            //    try
            //    {
            //        Console.WriteLine("Enter z2");
            //        z2 = Convert.ToInt32(Console.ReadLine());
            //        flag = false;
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //} while (flag);

            Point3D P1 = new Point3D(x1, y1, z1);
            Point3D P2 = new Point3D(x2, y2, z2);

            Console.WriteLine(P1.ToString());
            Console.WriteLine(P2.ToString());

            //use if (P1==P2)
            ///it doesnot work properly we must overload the == operator
            if(P1== P2)
                Console.WriteLine("identical points");
            else
                Console.WriteLine("different points");

        }
    }
}