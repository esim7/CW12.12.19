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
        public void SendeReport(string phoneNumber, string report)
        {
            string AccountSid = "AC8342d8d4276f3b549f9f2ca00a2c0d0a";
            string AuthToken = "1b0da09f5ad619addd9a972e0f9cede3";
            string Message = string.Empty;
            string VerificationCode = string.Empty;


            TwilioClient.Init(AccountSid, AuthToken);

            var to = new Twilio.Types.PhoneNumber(phoneNumber);
            var from = new Twilio.Types.PhoneNumber("+14842355664");
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: report);
        }
    }
}
