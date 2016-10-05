using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMaster.Helper;

namespace CineMaster.Models
{
    public class MovieGenre
    {
        public MovieGenre()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
