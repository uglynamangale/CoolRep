using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach1.Res
{
    internal class Employee
    {
        public Employee(int clientid, string login, string password, bool role)
        {
            WorkerID = clientid;
            Login = login;
            Password = password;
            Role = role;
        }
        public int WorkerID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Boolean Role { get; set; }
    }
}
