using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMaster.Models
{
    public class Session
    {
        public Session()
        {
            this.Movie = new Movie();
            this.MovieTheatre = new MovieTheatre();
            this.TicketList = new List<Ticket>();
        }

        public int SessionID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Movie Movie { get; set; }
        public MovieTheatre MovieTheatre { get; set; }
        public List<Ticket> TicketList { get; set; }

        public override string ToString()
        {
            return Movie.Name + " - " + Date.ToShortDateString() + " - " + Time + " Seansı";
        }
    }
}
