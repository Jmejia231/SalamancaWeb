using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class GenderController : Controller
    {
        Gender gender = new Gender();
        // GET: Gender
        public ActionResult Index()
        {
            var response = gender.getGenders();
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
                return Redirect(HomeController.Gender);
            }
            else
            {
                var response = gender.getGenderById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Gender);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new Gender());
            }
            else
            {
                var response = gender.getGenderById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Gender);
                }
            }
        }

        public ActionResult Save(Gender gender)
        {
            var response = gender.idGender == 0 ? gender.createGender() : gender.updateGender();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Gender);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(gender.getGenderById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.Gender);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = gender.deleteGenderById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Gender);
        }
    }
}