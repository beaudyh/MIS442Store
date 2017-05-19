using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}