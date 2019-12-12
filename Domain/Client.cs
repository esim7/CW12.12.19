using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string AccountNumber { get; set; }
        public int Cash { get; set; }

        public Client()
        {
            var random = new Random();
            Cash = 0;
            AccountNumber = random.Next(1000000, 9999999).ToString();
        }
    }
}
