using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public List<Registration> GetUserRegistrations(string username)
        {
            List<Registration> list = new List<Registration>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_BH"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "Select * From Registration";
                    command.CommandType = CommandType.Text;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Registration items = new Registration();

                            items.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            items.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            items.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            items.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            items.RegistrationVerified = bool.Parse(reader["RegistrationVerified"].ToString());
                            items.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            items.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            items.RegistrationState = reader["RegistrationState"].ToString();
                            items.RegistrationCity = reader["RegistrationCity"].ToString();
                            items.RegistrationZip = reader["RegistrationZip"].ToString();
                            items.RegistrationPhone = reader["RegistrationPhone"].ToString();
                            list.Add(items);
                        }
                    }
                }
            }
            return list;
        }

        public List<Registration> GetRegistrations()
        {
            List<Registration> list = new List<Registration>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_BH"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "Select * From Registration";
                    command.CommandType = CommandType.Text;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Registration items = new Registration();

                            items.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            items.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            items.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            items.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            items.RegistrationVerified = bool.Parse(reader["RegistrationVerified"].ToString());
                            items.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            items.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            items.RegistrationState = reader["RegistrationState"].ToString();
                            items.RegistrationCity = reader["RegistrationCity"].ToString();
                            items.RegistrationZip = reader["RegistrationZip"].ToString();
                            items.RegistrationPhone = reader["RegistrationPhone"].ToString();
                            list.Add(items);

                        }
                    }
                }
            }
            return list;
        }
        public Registration GetRegistration(int id)
        {
            Registration registration = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_BH"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "Select * From Registration Where RegistrationID = @RegistrationID";
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.Parameters.AddWithValue("@RegistrationUserName", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Registration items = new Registration();

                            registration.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            registration.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            registration.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            registration.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            registration.RegistrationVerified = bool.Parse(reader["RegistrationVerified"].ToString());
                            registration.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            registration.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            registration.RegistrationState = reader["RegistrationState"].ToString();
                            registration.RegistrationCity = reader["RegistrationCity"].ToString();
                            registration.RegistrationZip = reader["RegistrationZip"].ToString();
                            registration.RegistrationPhone = reader["RegistrationPhone"].ToString();
                        }
                    }
                }
                return registration;
            }
        }


        public void SaveRegistration(Registration registration)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_BH"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = @"Insert INTO Registration 
                    (RegistrationDate, RegistrationProductID, RegistrationSerialNumber, RegistrationVerified, 
                    RegistrationUserName, RegistrationAddress, RegistrationState, RegistrationCity, 
                    RegistrationZip, RegistrationPhone) VALUES 
                    (@RegistrationDate, @RegistrationProductID, @RegistrationSerialNumber, @RegistrationVerified, 
                    @RegistrationUserName, @RegistrationAddress, @RegistrationState, @RegistrationCity, 
                    @RegistrationZip, @RegistrationPhone)";
                    command.CommandType = CommandType.Text;
                    if (registration.RegistrationID != 0)
                    {
                        command.Parameters.AddWithValue("@RegistrationID", registration.RegistrationID);
                    }
                    command.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);
                    command.Parameters.AddWithValue("@RegistrationProductID", registration.RegistrationProductID);
                    command.Parameters.AddWithValue("@RegistrationSerialNumber", registration.RegistrationSerialNumber);
                    command.Parameters.AddWithValue("@RegistrationVerified", registration.RegistrationVerified);
                    command.Parameters.AddWithValue("@RegistrationUserName", registration.RegistrationUserName);
                    command.Parameters.AddWithValue("@RegistrationAddress", registration.RegistrationAddress);
                    command.Parameters.AddWithValue("@RegistrationState", registration.RegistrationState);
                    command.Parameters.AddWithValue("@RegistrationCity", registration.RegistrationCity);
                    command.Parameters.AddWithValue("@RegistrationZip", registration.RegistrationZip);
                    command.Parameters.AddWithValue("@RegistrationPhone", registration.RegistrationPhone);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}