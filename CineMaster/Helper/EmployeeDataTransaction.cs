using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMaster.Models;
using System.Data.SqlClient;
using System.Configuration;
using CineMaster.Enums;
using System.Data;

namespace CineMaster.Helper
{
    public static class EmployeeDataTransaction
    {
        public static List<Employee> GetEmployeeList()
        {
            List<Employee> employeeList = new List<Employee>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand selectCommand = new SqlCommand("SELECT ID, FirstName, LastName, NationalityNumber, GenderID, DateOfBirth, TitleID, PhoneNumber, Username, Password FROM Employee");
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeID = (int)dataReader["ID"];
                        employee.FirstName = (string)dataReader["FirstName"];
                        employee.LastName = (string)dataReader["LastName"];
                        employee.NationalityNumber = (string)dataReader["NationalityNumber"];
                        employee.Gender = (Gender)dataReader["GenderID"];
                        employee.DateOfBirth = (DateTime)dataReader["DateOfBirth"];
                        employee.Title = (Title)dataReader["TitleID"];
                        employee.PhoneNumber = (string)dataReader["PhoneNumber"];
                        employee.Username = (string)dataReader["Username"];
                        employee.Password = (string)dataReader["Password"];
                        employeeList.Add(employee);
                    }
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }


            return employeeList;
        }

        public static List<Employee> GetTicketSellers()
        {
            List<Employee> employeeList = new List<Employee>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand selectCommand = new SqlCommand("SELECT ID, FirstName, LastName, NationalityNumber, GenderID, DateOfBirth, TitleID, PhoneNumber, Username, Password FROM Employee WHERE TitleID = 2");
            selectCommand.Connection = sqlConnection;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlDataReader dataReader = selectCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeID = (int)dataReader["ID"];
                        employee.FirstName = (string)dataReader["FirstName"];
                        employee.LastName = (string)dataReader["LastName"];
                        employee.NationalityNumber = (string)dataReader["NationalityNumber"];
                        employee.Gender = (Gender)dataReader["GenderID"];
                        employee.DateOfBirth = (DateTime)dataReader["DateOfBirth"];
                        employee.Title = (Title)dataReader["TitleID"];
                        employee.PhoneNumber = (string)dataReader["PhoneNumber"];
                        employee.Username = (string)dataReader["Username"];
                        employee.Password = (string)dataReader["Password"];
                        employeeList.Add(employee);
                    }
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }


            return employeeList;
        }

        public static bool AddEmployee(Employee employee)
        {
            bool result = false;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = sqlConnection;
            insertCommand.CommandText = "INSERT INTO Employee (FirstName, LastName, NationalityNumber, GenderID, DateOfBirth, TitleID, PhoneNumber, Username, Password) VALUES (@firstName, @lastName, @natNumber, @genderId, @dateOfBirth, @titleId, @phoneNumber, @username, @password)";
            insertCommand.Parameters.AddWithValue("@firstName", employee.FirstName);
            insertCommand.Parameters.AddWithValue("@lastName", employee.LastName);
            insertCommand.Parameters.AddWithValue("@natNumber", employee.NationalityNumber);
            insertCommand.Parameters.AddWithValue("@genderId", employee.Gender.GetHashCode());
            insertCommand.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);
            insertCommand.Parameters.AddWithValue("@titleId", employee.Title.GetHashCode());
            insertCommand.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
            insertCommand.Parameters.AddWithValue("@username", employee.Username);
            insertCommand.Parameters.AddWithValue("@password", employee.Password);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                int employeeId = (int)insertCommand.ExecuteScalar();
                if (employeeId > 0)
                {
                    result = true;
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return result;
        }

        public static bool UpdateEmployee(Employee employee)
        {
            bool result = false;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = sqlConnection;
            updateCommand.CommandText = "UPDATE Employee SET FirstName = @firstName, LastName = @lastName, NationalityNumber = @natNumber, GenderID = @genderId, DateOfBirth = @dateOfBirth, TitleID = @titleId, PhoneNumber = @phoneNumber, Username = @username, Password = @password WHERE ID = @employeeId";
            updateCommand.Parameters.AddWithValue("@employeeId", employee.EmployeeID);
            updateCommand.Parameters.AddWithValue("@firstName", employee.FirstName);
            updateCommand.Parameters.AddWithValue("@lastName", employee.LastName);
            updateCommand.Parameters.AddWithValue("@natNumber", employee.NationalityNumber);
            updateCommand.Parameters.AddWithValue("@genderId", employee.Gender.GetHashCode());
            updateCommand.Parameters.AddWithValue("@dateOfBirth", employee.DateOfBirth);
            updateCommand.Parameters.AddWithValue("@titleId", employee.Title.GetHashCode());
            updateCommand.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
            updateCommand.Parameters.AddWithValue("@username", employee.Username);
            updateCommand.Parameters.AddWithValue("@password", employee.Password);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                int id = (int)updateCommand.ExecuteScalar();
                if (id > 0)
                {
                    result = true;
                }
            }
            catch (Exception) { throw; }
            finally { sqlConnection.Close(); }

            return result;
        }

        public static bool DeleteEmployee(int employeeId)
        {
            bool result = false;

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterCinemaConnection"].ConnectionString);

            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = sqlConnection;
            deleteCommand.CommandText = "DELETE FROM Employee WHERE ID = @employeeId";
            deleteCommand.Parameters.AddWithValue("@employeeId", employeeId);

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                int selectedEmployee = (int)deleteCommand.ExecuteScalar();
                if (selectedEmployee > 0)
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
