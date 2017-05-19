using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.DataModels;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MIS442Store.DataLayer.Repositories
{
    public class NewsRepository : INewsRepository
    {
        public List<News> GetList()
        {
            List<News> list = new List<News>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM News";
                    command.CommandType = CommandType.Text;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            News newsItem = new News();

                            newsItem.ID = int.Parse(reader["ID"].ToString());
                            newsItem.Title = reader["Title"].ToString();
                            newsItem.Author = reader["Author"].ToString();
                            newsItem.DatePosted = DateTime.Parse(reader["DatePosted"].ToString());
                            list.Add(newsItem);

                        }
                    }
                }
            }
            return list;
        }
    }
}