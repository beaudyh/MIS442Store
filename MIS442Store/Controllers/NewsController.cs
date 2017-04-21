using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            ViewBag.Title = "MIS442 News";
            ViewBag.Header = "MIS442 News";
            List<News> list = new List<News>();
            News item = new News();
            item.ID = 1;
            item.Title = "Boy hits Rock!";
            item.Body = "Boy punches a rock";
            item.Author = "Beaudy Harrington";
            item.DatePosted = Convert.ToDateTime("4/20/2017");
            list.Add(item);
            return View(GetNews());
        }
        private List<News> GetNews()
        {
            List<News> list = new List<News>();
            News items = new News();

            items.ID = 2;
            items.Title = "Girl hits Rock!";
            items.Body = "Girl punches a rock";
            items.Author = "Beaudy Harrington";
            items.DatePosted = Convert.ToDateTime("4/20/2017");

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
                        while(reader.Read())
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