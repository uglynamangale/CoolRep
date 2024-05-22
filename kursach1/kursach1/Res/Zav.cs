using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach1.Res
{
    internal class Zav
    {
        public Zav (int id,string companyname, string theme, bool status)
        {
            ID = id;
            CompanyName = companyname;
            Theme = theme;
            Status = status;
        }
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Theme { get; set; }
        public Boolean Status { get; set; }
       
    }
}
