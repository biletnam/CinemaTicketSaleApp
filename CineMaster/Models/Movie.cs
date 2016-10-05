using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMaster.Models
{
    public class Movie
    {
        public Movie()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }
        public List<MovieGenre> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public short Duration { get; set; }
        public byte[] Poster { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name + " - " + Duration + " dk.";
        }
    }
}
