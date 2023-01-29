namespace task3_NIC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NIC myNIC = NIC.GetNICCard();
            Console.WriteLine(myNIC.ToString());
            Console.WriteLine(myNIC.GetHashCode());

            NIC myNIC2 = NIC.GetNICCard();
            Console.WriteLine(myNIC2.ToString());
            Console.WriteLine(myNIC2.GetHashCode());

            //myNIC and myNIC2 are the same object with the same identity
            //the class applies singleton and can only create one object
        }
    }
}