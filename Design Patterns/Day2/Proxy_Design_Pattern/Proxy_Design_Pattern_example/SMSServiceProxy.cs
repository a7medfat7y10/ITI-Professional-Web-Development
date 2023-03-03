using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Design_Pattern_example
{
    //count the number of messages
    //if valid delegate the call to the sms
    public class SMSServiceProxy : SMSService
    {
        private SMSService _smsService;

        Dictionary<string, int> sentSmsCount = new Dictionary<string, int>();
        public override string SendSMS(string CustId, string mobile, string sms)
        {
            if(_smsService == null)
            {
                _smsService = new ConcreteSMSService();
            }
            //first sms sent
            if(!sentSmsCount.ContainsKey(CustId))
            {
                sentSmsCount.Add(CustId, 1);
                //delegate the call to the smsservice class
                return _smsService.SendSMS(CustId, mobile, sms);    
            } 
            else
            {
                var customer = sentSmsCount.Where(x => x.Key == CustId).FirstOrDefault();
                if (customer.Value >= 5)
                {
                    return "Quota exceeded, sms not sent";
                }
                else
                {
                    sentSmsCount[CustId] = customer.Value + 1;
                    //delegate the call to the smsservice class
                    return _smsService.SendSMS(CustId, mobile, sms);
                }
            }

            
        }
    }
}
