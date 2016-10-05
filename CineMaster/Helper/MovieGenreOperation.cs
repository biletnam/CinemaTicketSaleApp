using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMaster.Models;

namespace CineMaster.Helper
{
    public static class MovieGenreOperation
    {
        public static List<MovieGenre> GetMovieGenres()
        {
            List<MovieGenre> genreList = new List<MovieGenre>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand selectCommand = new SqlCommand("SELECT ID, Name FROM MovieGenre");
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();


                SqlDataReader dataReader = selectCommand.ExecuteReader();
                MovieGenre genre;
                while (dataReader.Read())
                {
                    genre = new MovieGenre();
                    genre.ID = (int)dataReader["ID"];
                    genre.Name = (string)dataReader["Name"];

                    genreList.Add(genre);
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return genreList;

        }

    }
}
