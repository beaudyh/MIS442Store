using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
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
        private INewsRepository _Repos;
        public NewsController()
        {
            _Repos = new NewsRepository();
        }
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
            return View(_Repos.GetList());
        }
      
    }
}