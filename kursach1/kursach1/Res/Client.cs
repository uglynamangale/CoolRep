using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach1.Res
{
    internal class Client
    {
        public Client(int clientid, string mail, string companyname)
        {
            ClientId = clientid;
            Mail = mail;
            CompanyName = companyname;
            
        }
        public int ClientId { get; set; }
        public string Mail { get; set; }
        public string CompanyName { get; set; }
    }
}
