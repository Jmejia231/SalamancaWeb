using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class UserTypeController : Controller
    {
        UserType userType = new UserType();
        // GET: User Type
        public ActionResult Index()
        {
            var response = userType.getUserTypes();
            if(!response.success)
            {
                UtilityClass.constructAlert(response.success, response.displayMessage);
            }
            return View(response.result);
        }

        public ActionResult Detail(string id)
        {
            if(String.IsNullOrEmpty(id))
            {
                return Redirect(HomeController.UserType);
            }
            else
            {
                var response = userType.getUserTypeById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.UserType);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new UserType());
            }
            else
            {
                var response = userType.getUserTypeById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.UserType);
                }
            }
        }

        public ActionResult Save(UserType userType)
        {
            var response = userType.idUserType == 0 ? userType.createUserType() : userType.updateUserType();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.UserType);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(userType.getUserTypeById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.UserType);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = userType.deleteUserTypeById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.UserType);
        }
    }
}
