using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class PersonController : Controller
    {
        Gender gender = new Gender();
        City city = new City();
        DocumentIdentityType documentIdentityType = new DocumentIdentityType();
        Person person = new Person();
        // GET: Person
        public ActionResult Index()
        {
            var response = person.getPersons();
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
                return Redirect(HomeController.Person);
            }
            else
            {
                var response = person.getPersonById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Person);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            ViewBag.documentIdentityTypes = documentIdentityType.initializeDocumentIdentityTypeItems();
            ViewBag.cities = city.initializeCityItems();
            ViewBag.genders = gender.initializeGenderItems();
            if(id == 0)
            {
                return View(new Person());
            }
            else
            {
                var response = person.getPersonById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Person);
                }
            }
        }

        public ActionResult Save(Person person)
        {
            //Asignar los Valores a los ID
            person.idDocumentIdentityType = person.documentIdentityType.idDocumentIdentityType;
            person.idCity = person.city.idCity;
            person.idGender = person.gender.idGender;
            //Anular los Objetos(Paises) = NULL
            person.documentIdentityType = null;
            person.city = null;
            person.gender = null;
            var response = person.idPerson == 0 ? person.createPerson() : person.updatePerson();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Person);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(person.getPersonById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.Person);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = person.deletePersonById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Person);
        }
    }
}