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
    public class ProductRepository : IProductRepository
    {
        public Product Get(int id)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_BH"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "Product_Get";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@ProductID", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           product = new Product();

                            product.ProductID = int.Parse(reader["ProductID"].ToString());
                            product.ProductCode = reader["ProductCode"].ToString();
                            product.ProductName = reader["ProductName"].ToString();
                            product.ProductVersion = decimal.Parse(reader["ProductVersion"].ToString());
                            product.ProductReleaseDate = DateTime.Parse(reader["ProductReleaseDate"].ToString());
                        }
                    }
                }
            }
            return product;
        }

        public List<Product> GetList()
        {
            List<Product> lists = new List<Product>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_BH"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "Product_GetList";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product item = new Product();

                            item.ProductID = int.Parse(reader["ProductID"].ToString());
                            item.ProductCode = reader["ProductCode"].ToString();
                            item.ProductName = reader["ProductName"].ToString();
                            item.ProductVersion = decimal.Parse(reader["ProductVersion"].ToString());
                            item.ProductReleaseDate = DateTime.Parse(reader["ProductReleaseDate"].ToString());
                            lists.Add(item);

                        }
                    }
                }
            }
            return lists;
        }

        public void Save(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_BH"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "Product_InsertUpdate";
                    command.CommandType = CommandType.StoredProcedure;
                    if (product.ProductID != 0)
                    {
                        command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    }
                    command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@ProductVersion", product.ProductVersion);
                    command.Parameters.AddWithValue("@ProductReleaseDate", product.ProductReleaseDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}