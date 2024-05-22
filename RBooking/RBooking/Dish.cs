using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBooking
{
    public class Dish
    {
        public Dish(string name,string category,string descryption, int price, int calories, int mass)
        {
            Name = name;
            Category = category;
            Descryption = descryption;
            Price = price;
            Calories = calories;
            Mass = mass;
        }
        public string Name { get; set; }    
        public string Category { get; set; }
        public string Descryption { get; set; }
        public int Price { get; set; }
        public int Calories { get; set; }
        public int Mass { get; set; }
    }
}
