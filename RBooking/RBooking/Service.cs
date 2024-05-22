using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBooking
{
    public class Service
    {
        public Service(string name,string description, int price, int hour) 
        {
            Name = name;
            Description = description;
            Price = price;
            Hour = hour;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Hour { get; set; }
    }
}
