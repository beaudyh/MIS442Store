using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using MIS442Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class RegistrationController : Controller
    {
        private IRegistrationRepository _Repos;
        private IStateRepository _Repo;
        public RegistrationController()
        {
            _Repos = new RegistrationRepository();
            _Repo = new StateRepository();
        }
        // GET: Registration
        [HttpGet]
        public ActionResult Index()
        {
            return View(_Repos.GetUserRegistrations("DaBeau96"));
        }

        [HttpGet]
        public ActionResult AddRegistration()
        {
            RegistrationModel reg = new RegistrationModel();
            reg.States = _Repo.GetState();
            return View(reg);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddRegistration(RegistrationModel registation)
        {
            if (!ModelState.IsValid)
            {
                registation.States = _Repo.GetState();
                return View(registation);
            }
            Registration regData = new Registration();
            regData.RegistrationID = registation.RegistrationID;
            regData.RegistrationDate = registation.RegistrationDate;
            regData.RegistrationProductID = registation.RegistrationProductID;
            regData.RegistrationSerialNumber = registation.RegistrationSerialNumber;
            regData.RegistrationVerified = registation.RegistrationVerified;
            regData.RegistrationUserName = User.Identity.Name;
            regData.RegistrationAddress = registation.RegistrationAddress;
            regData.RegistrationState = registation.RegistrationState;
            regData.RegistrationCity = registation.RegistrationCity;
            regData.RegistrationZip = registation.RegistrationZip;
            regData.RegistrationPhone = registation.RegistrationPhone;

            _Repos.SaveRegistration(regData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminIndex()
        {
            return View(_Repos.GetRegistrations());
        }
    }
}