using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQHW13
{
    class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public string GroupName { get; set; }
        public double Grade { get; set; }

        public Student(string _name, string _surname, string _city, string _groupName, int _grade )
        {
            Name = _name;
            SurName = _surname;
            City = _city;
            GroupName = _groupName;
            Grade = _grade;

        }
        public override string ToString()
        {
            return $"Name: {Name} \n" +
                   $"Surname: {SurName} \n" +
                   $"City: {City} \n" +
                   $"Group name: {GroupName} \n" +
                   $"Grade: {Grade} \n";

        }
    }

}
