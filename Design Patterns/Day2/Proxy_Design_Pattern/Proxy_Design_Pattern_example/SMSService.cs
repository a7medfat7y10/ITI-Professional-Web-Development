using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Design_Pattern_example
{
    public abstract class SMSService
    {
        public abstract string SendSMS(string CustId, string mobile, string sms);
    }

    public class ConcreteSMSService : SMSService
    {
        public override string SendSMS(string CustId, string mobile, string sms)
        {
            return $"Customer {CustId} sent an sms to {mobile}";
        }
    }
}
