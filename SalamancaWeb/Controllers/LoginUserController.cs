using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers {
    public class LoginUserController : Controller {
        LoginUser loginUser = new LoginUser();
        Person person = new Person();
        UserType userType = new UserType();
        // GET: User
        public ActionResult Index() {
            var response = loginUser.getUsers();
            if(!response.success)
            {
                UtilityClass.constructAlert(response.success, response.displayMessage);
            }
            return View(response.result);
        }

        public ActionResult Detail(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect(HomeController.LoginUser);
            } else {
                var response = loginUser.getUserById(Convert.ToInt32(id));
                if(response.result != null) {
                    return View(response.result);
                } else {
                    return Redirect(HomeController.LoginUser);
                }
            }
        }

        public ActionResult AddEdit(int id = 0) {
            ViewBag.persons = person.initializeNoPatientsPersonItems();
            ViewBag.userTypes = userType.initializeUserTypeItems();
            if(id == 0) {
                return View(new LoginUser());
            } else {
                var response = loginUser.getUserById(id);
                if(response.result != null) {
                    return View(response.result);
                } else {
                    return Redirect(HomeController.LoginUser);
                }
            }
        }

        public ActionResult Save(LoginUser loginUser) {
            //dando valores a los ID
            loginUser.idPerson = loginUser.person.idPerson;
            loginUser.idUserType = loginUser.userType.idUserType;
            loginUser.dateCreated = DateTime.UtcNow.AddHours(Convert.ToInt32(Resource.GMT_5));
            //NULEAR LAS WEADAS
            loginUser.person = null;
            loginUser.userType = null;
            var response = loginUser.idLoginUser == 0 ? loginUser.createUser() : loginUser.updateUser();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.LoginUser);
        }

        [HttpGet]
        public ActionResult Delete(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(loginUser.getUserById(Convert.ToInt32(id)).result);
            } else {
                return Redirect(HomeController.LoginUser);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id) {
            var response = loginUser.deleteUserById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.LoginUser);
        }
    }
}