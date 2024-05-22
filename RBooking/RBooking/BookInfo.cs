using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBooking
{
    public class BookInfo
    {
        public BookInfo(string date,string time,string lenght,string user) 
        {
            Date = date.Split()[0];
            Time = time;
            Lenght = lenght;
            User = user;
        }
        public string Date { get; set; } 
        public string Time { get; set; } 
        public string Lenght { get; set; } 
        public string User { get; set; } 
    }
}
