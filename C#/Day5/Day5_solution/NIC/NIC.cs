using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace task3_NIC
{
    internal class NIC
    {
        string Manufacture;
        string MacAddress;
        Type type;

        //Singleton pattern 
        static NIC SingleNIC;

        NIC(string _m, string _mac, Type t)
        {
            Manufacture = _m;
            MacAddress = _mac;
            type = t;
        }

        public static NIC GetNICCard()
        {
            if (SingleNIC == null)
                SingleNIC = new NIC("Dell", "01-23-45-67-89-AB", Type.Ethernet);

            return SingleNIC;
        }

        public override string ToString()
        {
            return $"Manufacture: {Manufacture}\n" +
                    $"macAddress: {MacAddress}\n" +
                    $"type: {type} ";
        }
    }
    enum Type
    {
        Ethernet, token, ring
    }
}
