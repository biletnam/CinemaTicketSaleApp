using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMaster.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace CineMaster.Helper
{
    public static class MovieTheatreOperation
    {
        public static List<MovieTheatre> GetTheatreList()
        {
            List<MovieTheatre> theatreList = new List<MovieTheatre>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand selectCommand = new SqlCommand("SELECT ID, Name, SeatingCapacity FROM MovieTheater");
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();


                SqlDataReader dataReader = selectCommand.ExecuteReader();
                MovieTheatre theatre;
                while (dataReader.Read())
                {
                    theatre = new MovieTheatre();
                    theatre.MovieTheatreID = (int)dataReader["ID"];
                    theatre.MovieTheatreName = (string)dataReader["Name"];
                    theatre.SeatingCapacity = (byte)dataReader["SeatingCapacity"];

                    theatreList.Add(theatre);
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return theatreList;
        }
    }
}
