using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMaster.Models
{
    public class MovieTheatre
    {
        public MovieTheatre()
        {

        }

        public int MovieTheatreID { get; set; }
        public string MovieTheatreName { get; set; }
        public byte SeatingCapacity { get; set; }

        public override string ToString()
        {
            return MovieTheatreID + ") " + MovieTheatreName + " - Kapasite: " + SeatingCapacity;
        }
    }
}
