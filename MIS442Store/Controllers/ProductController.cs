using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _Repos;
        public ProductController()
        {
            _Repos = new ProductRepository();
        }
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            return View(_Repos.GetList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            _Repos.Save(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = _Repos.Get(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _Repos.Save(product);
            return RedirectToAction("Index");
        }
    }
}