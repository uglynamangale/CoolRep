using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach1.Res
{
    internal class Car
    {
        public Car (string auto_brand, string model, string car_number, int probeg, int wear)
        {
            Auto_brand = auto_brand;
            Model = model;
            Car_Number = car_number;
            Probeg = probeg;
            Wear = wear;
        }
        public string Auto_brand { get; set; }
        public string Model { get; set; }
        public string Car_Number { get; set; }
        public int Probeg { get; set; }
        public int Wear { get; set; }
    }
}
