using CineMaster.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMaster.Enums;

namespace CineMaster.Helper
{
    public static class SessionDataTransaction
    {
        public static List<Session> GetAllSessions()
        {
            List<Session> sessionList = new List<Session>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand selectCommand = new SqlCommand("SELECT Session.ID, Session.Date, Session.Time, Movie.ID, Movie.Name, Session.MovieTheatreID FROM Session INNER JOIN Movie ON Session.MovieID = Movie.ID");
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlDataReader dataReader = selectCommand.ExecuteReader();
                Session session;
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        session = new Session();
                        session.SessionID = (int)dataReader[0];
                        session.Date = (DateTime)dataReader[1];
                        session.Time = (TimeSpan)dataReader[2];
                        session.Movie.ID = (int)dataReader[3];
                        session.Movie.Name = (string)dataReader[4];
                        session.MovieTheatre.MovieTheatreID = (int)dataReader[5];
                        sessionList.Add(session);
                    }
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return sessionList;
        }

        public static List<Session> GetAvailableSessions()
        {
            List<Session> sessionList = new List<Session>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand selectCommand = new SqlCommand("SELECT Session.ID, Session.Date, Session.Time, Movie.ID, Movie.Name, Session.MovieTheatreID FROM Session INNER JOIN Movie ON Session.MovieID = Movie.ID");
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlDataReader dataReader = selectCommand.ExecuteReader();
                Session session;
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        session = new Session();
                        session.SessionID = (int)dataReader[0];
                        session.Date = (DateTime)dataReader[1];
                        session.Time = (TimeSpan)dataReader[2];
                        session.Movie.ID = (int)dataReader[3];
                        session.Movie.Name = (string)dataReader[4];
                        session.MovieTheatre.MovieTheatreID = (int)dataReader[5];
                        sessionList.Add(session);
                    }
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return sessionList;
        }

        public static void GetSessionDetailsById(Session session)
        {
            if (session.TicketList != null && session.TicketList.Count > 0)
            {
                return;
            }

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);
            SqlCommand selectCommand = new SqlCommand("SELECT t.ID, t.AudienceTypeID, t.SessionID, t.SellerID, t.SeatNumber, t.Price FROM Ticket t INNER JOIN Session_Ticket s_t ON t.ID = s_t.TicketID WHERE s_t.SessionID = @sessionId ");
            selectCommand.Parameters.AddWithValue("@sessionId", session.SessionID);
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlDataReader dataReader = selectCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    session.TicketList = new List<Ticket>();
                    while (dataReader.Read())
                    {
                        Ticket ticket = new Ticket();
                        ticket.TicketID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
                        ticket.AudienceType = (AudienceType)dataReader["AudienceTypeID"];
                        ticket.Session = (Session)dataReader["SessionID"];
                        ticket.Seller = (Employee)dataReader["SellerID"];
                        ticket.SeatNumber = (short)dataReader["SeatNumber"];
                        ticket.Price = (byte)dataReader["Price"];
                        session.TicketList.Add(ticket);
                    }
                }

            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }


        }

        public static bool AddTicketToSession(int sessionId, List<Ticket> ticketList)
        {
            bool result = false;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = sqlConnection;
            StringBuilder sBuilder = new StringBuilder("INSERT INTO Session_Ticket (SessionID, TicketID) VALUES");

            foreach (Ticket ticket in ticketList)
            {
                sBuilder.AppendFormat("({0}, {1}),", sessionId, ticket.TicketID);
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

        public static bool AddSession(Session session)
        {
            bool result = false;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = sqlConnection;
            insertCommand.CommandText = "INSERT INTO Session (Date, Time, MovieID, MovieTheatreID) VALUES (@date, @time, @movieId, @movieTheatreId); SELECT @@IDENTITY";
            insertCommand.Parameters.AddWithValue("@date", session.Date);
            insertCommand.Parameters.AddWithValue("@time", session.Time);
            insertCommand.Parameters.AddWithValue("@movieId", session.Movie.ID);
            insertCommand.Parameters.AddWithValue("@movieTheatreId", session.MovieTheatre.MovieTheatreID);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                int sessionId = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (sessionId > 0)
                {
                    result = true;
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return result;
        }

        private static bool DeleteTicketFromSession(int ticketId, List<Ticket> ticketList)
        {
            bool result = false;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = sqlConnection;
            deleteCommand.CommandText = "DELETE FROM Session_Ticket WHERE TicketID = @ticketId";
            deleteCommand.Parameters.AddWithValue("@ticketId", ticketId);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                result = deleteCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return result;
        }

        public static bool UpdateSession(Session session)
        {
            bool result = false;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = sqlConnection;
            updateCommand.CommandText = "UPDATE Session SET Date = @date, Time = @time, MovieID = @movieId, MovieTheatreID = @mtId WHERE ID = @sessionId";
            updateCommand.Parameters.AddWithValue("@date", session.Date);
            updateCommand.Parameters.AddWithValue("@time", session.Time);
            updateCommand.Parameters.AddWithValue("@movieId", session.Movie.ID);
            updateCommand.Parameters.AddWithValue("@mtId", session.MovieTheatre.MovieTheatreID);
            updateCommand.Parameters.AddWithValue("@sessionId", session.SessionID);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                int sessionId = Convert.ToInt32(updateCommand.ExecuteScalar());
                if (sessionId > 0)
                {
                    result = true;
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return result;
        }

    }
}
