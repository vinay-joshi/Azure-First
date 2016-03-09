using Azure_First.Web.Data.Contract;
using Azure_First.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Azure_First.Web.Extensions;

namespace Azure_First.Web.Controllers
{
    public class DashboardController : Controller
    {
        private IAzureFirstRepository _repository;
        private string _userName;
        #region Construcor
        public DashboardController(IAzureFirstRepository repository)
        {
            this._repository = repository;
           // this._userName = Convert.ToString(Session["UserName"]);
        }

        #endregion

        // GET: Dashboard
        #region Get Dashboard data
        public ActionResult Index()
        {
            _userName = Convert.ToString(Session["UserName"]);
            var dashBoardViewModel = new DashboardViewModel();
            dashBoardViewModel.UserProfile = _repository.GetProfileByUserName(_userName);
            dashBoardViewModel.ExistingUsers = _repository.GetRandomProfiles(6);
            return View(dashBoardViewModel);
        }
        #endregion

        #region Users
        public ActionResult Users()
        {
            IEnumerable<RandomProfileViewModel> users = _repository.GetRandomProfiles(6);
            return View(users);
        }
        #endregion

        #region Profile
        public ActionResult UserProfile(string name , bool isMember = false)
        {
            if (isMember)
                return View(_repository.GetProfile(name));
            else
                return View(_repository.GetProfileByUserName(name));
        }

        public ActionResult EditUserProfile(string userName)
        {
            return View(_repository.GetUserProfileForEdit(userName));
        }

        [HttpPost]
        public ActionResult EditUserProfile(EditProfileViewModel model)
        {
            var age = model.Birthdate.CalculateAge();

            //if(age < 18 || age > 100)
            //{
            //    ModelState.AddModelError("Birthdate", "You mest be between 18 to 100");
            //}
           
            if (ModelState.IsValid)
            {
                var profile = _repository.GetProfile(model.MemberName);
                //update
                profile.Introduction = model.Introduction;
                profile.LookingFor = model.LookingFor;
                profile.Pitch = model.Pitch;
                profile.Demographics.Birthdate = model.Birthdate;
                profile.Demographics.Gender = model.Gender;
                profile.Demographics.Orientation = model.Orientation;

               if(_repository.SaveAll())
                {
                    return RedirectToAction("EditUserProfile"); 
                }
            }
            return View(_repository.GetUserProfileForEdit(_repository.GetUserNameByMemberName(model.MemberName)));
        }
        #endregion

    }
}