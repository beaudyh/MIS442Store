using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.DataModels
{
    public class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime DatePosted { get; set; }
    }
}