using CineMaster.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMaster.Models
{
    public class Employee
    {
        public Employee()
        { }

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalityNumber { get; set; }
        public Gender Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " - " + Gender + " - " + DateOfBirth.ToShortDateString() + " - " + Title + " - " + NationalityNumber + " - " + PhoneNumber;
        }

    }
}
