using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach1.Res
{
    internal class Voditel
    {
        public Voditel(int driver_id, string name, string surname, string driving_license, string phone_number)
        {
            Driver_ID = driver_id;
            Name = name;
            Surname = surname;
            Driving_License = driving_license;
            Phone_number = phone_number;
        }
        public int Driver_ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Driving_License { get; set; }
        public string Phone_number { get; set; }
    }
}
