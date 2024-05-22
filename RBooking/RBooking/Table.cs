using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBooking
{
    public class Table
    {
        public Table(int table_Num, int hall_Num, int people, double price)
        {
            Table_Num = table_Num;
            Hall_Num = hall_Num;
            People = people;
            Price = price;
        }

        public int Table_Num { get; set; }
        public int Hall_Num { get; set; }
        public int People { get; set; }
        public double Price { get; set; }
    }
}
