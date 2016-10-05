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
    public static class MovieDataTransaction
    {
        public static List<Movie> GetAllMovies()
        {
            List<Movie> movieList = new List<Movie>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand selectCommand = new SqlCommand("SELECT ID, Name, ReleaseDate, Duration, Poster, Description FROM Movie");
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlDataReader dataReader = selectCommand.ExecuteReader();
                Movie movie;
                if(dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        movie = new Movie();
                        movie.ID = (int)dataReader["ID"];
                        movie.Name = (string)dataReader["Name"];
                        movie.ReleaseDate = (DateTime)dataReader["ReleaseDate"];
                        movie.Description = (string)dataReader["Description"];
                        movie.Poster = dataReader.IsDBNull(dataReader.GetOrdinal("Poster")) ? null : (byte[])dataReader["Poster"];
                        movie.Duration = (short)dataReader["Duration"];
                        movieList.Add(movie);
                    }
                }                
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }


            return movieList;
        }

        public static List<Movie> GetActualMovies()
        {
            List<Movie> movieList = new List<Movie>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand selectCommand = new SqlCommand("SELECT TOP 10 ID, Name, Duration, ReleaseDate FROM Movie ORDER BY ReleaseDate DESC");
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlDataReader dataReader = selectCommand.ExecuteReader();
                Movie movie;
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        movie = new Movie();
                        movie.ID = (int)dataReader["ID"];
                        movie.Name = (string)dataReader["Name"];
                        movie.ReleaseDate = (DateTime)dataReader["ReleaseDate"];
                        movie.Duration = (short)dataReader["Duration"];
                        movieList.Add(movie);
                    }
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }


            return movieList;
        }

        public static void GetMovieDetailsById(Movie movie)
        {
            if (movie.Genres != null && movie.Genres.Count > 0)
            {
                return;
            }

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);
            SqlCommand selectCommand = new SqlCommand("SELECT ID, Name FROM Movie_MovieGenre m_mg INNER JOIN MovieGenre mg ON mg.ID = m_mg.MovieGenreID WHERE MovieID = @movieId");
            selectCommand.Parameters.AddWithValue("@movieId", movie.ID);
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    movie.Genres = new List<MovieGenre>();
                    while (dataReader.Read())
                    {
                        MovieGenre mGenre = new MovieGenre();
                        mGenre.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
                        mGenre.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                        movie.Genres.Add(mGenre);
                    }
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }
        }

        public static bool AddMovie(Movie movie)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = sqlConnection;
            insertCommand.CommandText = "INSERT INTO Movie (Name, Duration, ReleaseDate, Poster, Description) VALUES (@movieName, @duration, @releaseDate, @poster, @description); SELECT @@IDENTITY;";
            insertCommand.Parameters.AddWithValue("@movieName", movie.Name);
            insertCommand.Parameters.AddWithValue("@duration", movie.Duration);
            insertCommand.Parameters.AddWithValue("@releaseDate", movie.ReleaseDate);
            insertCommand.Parameters.AddWithValue("@poster", movie.Poster);
            insertCommand.Parameters.AddWithValue("@description", movie.Description);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                int movieId = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (movieId > 0)
                {
                    result = AddGenreToMovie(movieId, movie.Genres);
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }
            return result;
        }

        private static bool AddGenreToMovie(int movieId, List<MovieGenre> genreList)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = sqlConnection;
            StringBuilder sBuilder = new StringBuilder("INSERT INTO Movie_MovieGenre(MovieID, MovieGenreID) VALUES");
            foreach (MovieGenre genre in genreList)
            {
                sBuilder.AppendFormat("({0}, {1}),", movieId, genre.ID);
            }
            string cmdText = sBuilder.ToString();
            insertCommand.CommandText = cmdText.Remove(cmdText.Length - 1, 1);
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                result = insertCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return result;
        }

        public static bool UpdateMovie(Movie movie)
        {
            bool result = true;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = sqlConnection;
            updateCommand.CommandText = "UPDATE Movie SET Name = @name, Duration = @duration, ReleaseDate = @releaseDate, Poster = @poster, Description = @description WHERE ID = @movieId";
            updateCommand.Parameters.AddWithValue("@movieId", movie.ID);
            updateCommand.Parameters.AddWithValue("@name", movie.Name);
            updateCommand.Parameters.AddWithValue("@duration", movie.Duration);
            updateCommand.Parameters.AddWithValue("@releaseDate", movie.ReleaseDate);
            updateCommand.Parameters.AddWithValue("@poster", movie.Poster);
            updateCommand.Parameters.AddWithValue("@description", movie.Description);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                int affectedRowCount = updateCommand.ExecuteNonQuery();
                if (affectedRowCount > 0)
                {
                    result = UpdateMovieGenres(movie.ID, movie.Genres);
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return result;
        }

        private static bool UpdateMovieGenres(int movieId, List<MovieGenre> genreList)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = sqlConnection;
            updateCommand.Parameters.AddWithValue("@movieId", movieId);
            StringBuilder sBuilder = new StringBuilder("DELETE FROM Movie_MovieGenre WHERE MovieID = @movieId; INSERT INTO Movie_MovieGenre (MovieID, MovieGenreID) VALUES");

            foreach (MovieGenre genre in genreList)
            {
                sBuilder.AppendFormat("({0}, {1}),", movieId, genre.ID);
            }
            string cmdText = sBuilder.ToString();
            updateCommand.CommandText = cmdText.Remove(cmdText.Length - 1, 1);
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                result = updateCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return result;
        }
    }
}
