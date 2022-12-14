using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers {
    public class CityController : Controller {
        Country country = new Country();
        City city = new City();
        // GET: City
        public ActionResult Index() {
            var response = city.getCities();
            if(!response.success)
            {
                UtilityClass.constructAlert(response.success, response.displayMessage);
            }
            return View(response.result);
        }

        public ActionResult Detail(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect(HomeController.City);
            } else {
                var response = city.getCityById(Convert.ToInt32(id));
                if(response.result != null) {
                    return View(response.result);
                } else {
                    return Redirect(HomeController.City);
                }
            }
        }

        public ActionResult AddEdit(int id = 0) {
            ViewBag.countries = country.initializeCountryItems();
            if(id == 0) {
                return View(new City());
            } else {
                var response = city.getCityById(id);
                if(response.result != null) {
                    return View(response.result);
                } else {
                    return Redirect(HomeController.City);
                }
            }
        }

        public ActionResult Save(City city) {
            //Asignar los Valores a los ID
            city.idCountry = city.country.idCountry;
            //Anular los Objetos(Paises) = NULL
            city.country = null;
            var response = city.idCountry == 0 ? city.createCity() : city.updateCity();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.City);
        }

        [HttpGet]
        public ActionResult Delete(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(city.getCityById(Convert.ToInt32(id)).result);
            } else {
                return Redirect(HomeController.City);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id) {
            var response = city.deleteCityById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.City);
        }
    }
}