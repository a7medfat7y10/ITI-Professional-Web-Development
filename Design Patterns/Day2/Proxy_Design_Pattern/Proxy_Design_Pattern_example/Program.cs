namespace Proxy_Design_Pattern_example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SMSServiceProxy proxy = new SMSServiceProxy();
            Console.WriteLine(proxy.SendSMS("123", "01004322030", "Hi Ahmed msg1"));
            Console.WriteLine(proxy.SendSMS("123", "01004322030", "Hi Ahmed msg2"));
            Console.WriteLine(proxy.SendSMS("123", "01004322030", "Hi Ahmed msg3"));
            Console.WriteLine(proxy.SendSMS("123", "01004322030", "Hi Ahmed msg4"));
            Console.WriteLine(proxy.SendSMS("123", "01004322030", "Hi Ahmed msg5"));
            Console.WriteLine(proxy.SendSMS("123", "01004322030", "Hi Ahmed msg6"));
        }
    }
}