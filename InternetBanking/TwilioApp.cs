using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace InternetBanking
{
    public class TwilioApp
    {
        public ActionWindow ActionWindow { get; set; }
        public TwilioApp(string phoneNumber, string message)
        {
            SendReport(phoneNumber, message);
        }
        public void SendReport(string phoneNumber, string report)
        {
            string AccountSid = "AC67fcdfdc3ed144c763b1324cca3a2ab0";
            string AuthToken = "6fa17b35f0e6116e9351e5ff456be624";
            string Message = string.Empty;
            string VerificationCode = string.Empty;


            TwilioClient.Init(AccountSid, AuthToken);

            var to = new Twilio.Types.PhoneNumber(phoneNumber);
            var from = new Twilio.Types.PhoneNumber("+14243757512");
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: report);
        }
    }
}
