using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class CountryController : Controller
    {
        Country country = new Country();
        // GET: Country
        public ActionResult Index()
        {
            var response = country.getCountries();
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
                return Redirect(HomeController.Country);
            }
            else
            {
                var response = country.getCountryById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Country);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new Country());
            }
            else
            {
                var response = country.getCountryById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Country);
                }
            }
        }

        public ActionResult Save(Country country)
        {
            var response = country.idCountry == 0 ? country.createCountry() : country.updateCountry();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Country);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(country.getCountryById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.Country);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = country.deleteCountryById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Country);
        }
    }
}