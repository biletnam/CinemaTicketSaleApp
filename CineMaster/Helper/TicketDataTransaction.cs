using CineMaster.Enums;
using CineMaster.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMaster.Helper
{
    public static class TicketDataTransaction
    {
        public static List<Ticket> GetTicketList(Session session)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);
            SqlCommand selectCommand = new SqlCommand(@"SELECT Ticket.ID, Ticket.AudienceTypeID, Session.ID, Employee.ID, Ticket.SeatNumber, Ticket.Price
                                                        FROM Ticket
                                                        INNER JOIN Session_Ticket ON Ticket.ID = [Session_Ticket].TicketID
                                                        INNER JOIN Session ON Ticket.SessionID = Session.ID
                                                        INNER JOIN Employee ON Ticket.SellerID = Employee.ID
                                                        WHERE Ticket.SessionID = @sessionId");
            selectCommand.Parameters.AddWithValue("sessionId", session.SessionID);
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
                        ticket.TicketID = (int)dataReader[0];
                        ticket.AudienceType = (AudienceType)dataReader[1];
                        ticket.Session.SessionID = (int)dataReader[2];
                        ticket.Seller.EmployeeID = (int)dataReader[3];
                        ticket.SeatNumber = (short)dataReader[4];
                        ticket.Price = (byte)dataReader[5];
                        session.TicketList.Add(ticket);
                    }
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return session.TicketList;
        }

        public static List<Ticket> GetTicketDetail(Session session)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);
            SqlCommand selectCommand = new SqlCommand(@"SELECT Ticket.ID, Movie.Name, Employee.FirstName, Employee.LastName, Ticket.SeatNumber, Ticket.Price
                                                        FROM Ticket
                                                        INNER JOIN Session_Ticket ON Ticket.ID = [Session_Ticket].TicketID
                                                        INNER JOIN Session ON Ticket.SessionID = Session.ID
                                                        INNER JOIN Movie ON Session.MovieID = Movie.ID
                                                        INNER JOIN Employee ON Ticket.SellerID = Employee.ID
                                                        WHERE Ticket.SessionID = @sessionId");
            selectCommand.Parameters.AddWithValue("sessionId", session.SessionID);
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
                        ticket.TicketID = (int)dataReader[0];
                        ticket.Session.Movie.Name = (string)dataReader[1];
                        ticket.Seller.FirstName = (string)dataReader[2];
                        ticket.Seller.LastName = (string)dataReader[3];
                        ticket.SeatNumber = (short)dataReader[4];
                        ticket.Price = (byte)dataReader[5];
                        session.TicketList.Add(ticket);
                    }
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return session.TicketList;
        }

        public static bool AddTicket(Ticket ticket)
        {
            bool result = false;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = sqlConnection;
            insertCommand.CommandText = "INSERT INTO Ticket (AudienceTypeID, SessionID, SellerID, SeatNumber, Price) VALUES (@audienceTypeId, @sessionId, @sellerId, @seatNumber, @price); INSERT INTO Session_Ticket (SessionID, TicketID) VALUES (@sessionId, @@IDENTITY)";
            insertCommand.Parameters.AddWithValue("@audienceTypeId", ticket.AudienceType.GetHashCode());
            insertCommand.Parameters.AddWithValue("@sessionId", ticket.Session.SessionID);
            insertCommand.Parameters.AddWithValue("@sellerId", ticket.Seller.EmployeeID);
            insertCommand.Parameters.AddWithValue("@seatNumber", ticket.SeatNumber);
            insertCommand.Parameters.AddWithValue("@price", ticket.Price);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                int ticketId = Convert.ToInt32(insertCommand.ExecuteScalar());
                if (ticketId > 0)
                {
                    result = true;
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }


            return result;
        }

        public static bool DeleteTicket(Ticket ticket)
        {
            bool result = false;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = sqlConnection;
            deleteCommand.CommandText = "DELETE FROM Ticket WHERE ID = @ticketId";
            deleteCommand.Parameters.AddWithValue("@ticketId", ticket.TicketID);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                int ticketId = (int)deleteCommand.ExecuteScalar();

                if (ticketId > 0)
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
