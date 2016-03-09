using Azure_First.Web.Data.Contract;
using Azure_First.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Azure_First.Web.Controllers
{
    public class LoginController : Controller
    {
        IAccountReopsitory _accountRepo;
        public LoginController(IAccountReopsitory accountRepo)
        {
            this._accountRepo = accountRepo;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login loginDetails)
        {
            if (ModelState.IsValid)
            {
                // save Login data 
                if(_accountRepo.IsAutenticated(loginDetails.UserName,loginDetails.Passwrod))
                {
                    Session["UserName"] = loginDetails.UserName;

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("Error", "Credentials not found !");
                }
            }

            //return Redirect("/Admin/AdminLogin");
            return View("Index");
        }
    }
}