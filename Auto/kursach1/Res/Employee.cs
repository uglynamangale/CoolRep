using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach1.Res
{
    internal class Employee
    {
        public Employee(int employee_id, string name, string surname, string job_title, string phone_number)
        {
            Employee_ID = employee_id;
            Name = name;
            Surname = surname;
            job_Title = job_title;
            Phone_number = phone_number;
        }
        public int Employee_ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string job_Title { get; set; }
        public string Phone_number { get; set; }
    }
}
