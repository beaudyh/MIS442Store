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
    public class StateRepository : IStateRepository
    {
        public List<USState> GetState()
        {
            List<USState> list = new List<USState>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_BH"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM State";
                    command.CommandType = CommandType.Text;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            USState item = new USState();

                            item.code = reader["code"].ToString();
                            item.name = reader["name"].ToString();
                            list.Add(item);
                        }
                    }
                    return list;
                }
            }
        }
    }
}