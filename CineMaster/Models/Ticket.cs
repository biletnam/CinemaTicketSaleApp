using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMaster.Enums;

namespace CineMaster.Models
{
    public class Ticket
    {
        public Ticket()
        {
            this.Session = new Session();
            this.Seller = new Employee();
        }

        public int TicketID { get; set; }
        public AudienceType AudienceType { get; set; }
        public Session Session { get; set; }
        public Employee Seller { get; set; } 
        public short SeatNumber { get; set; }
        public byte Price { get; set; }

        public override string ToString()
        {
            return "Bilet numarası:" + TicketID + " - " + Session.Movie.Name + " - " + " Bileti satan yetkili: " + Seller.FirstName + " " + Seller.LastName + " - Koltuk no: " + SeatNumber;
        }
    }
}
