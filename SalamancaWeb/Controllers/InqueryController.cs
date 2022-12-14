using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class InqueryController : Controller
    {
        Person person = new Person();
        Inquery inquery = new Inquery();
        // GET: City
        public ActionResult Index()
        {
            var response = inquery.getInqueries();
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
                return Redirect(HomeController.Inquery);
            }
            else
            {
                var response = inquery.getInqueryById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Inquery);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            ViewBag.persons = person.initializePatientsPersonItems();
            if(id == 0)
            {
                return View(new Inquery());
            }
            else
            {
                var response = inquery.getInqueryById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Inquery);
                }
            }
        }

        public ActionResult Save(Inquery inquery)
        {
            //Asignar los Valores a los ID
            inquery.idPerson = inquery.person.idPerson;
            //Anular los Objetos(Paises) = NULL
            inquery.person = null;
            inquery.dateTime = inquery.idInquery == 0 ? DateTime.UtcNow.AddHours(Convert.ToInt32(Resource.GMT_5)) : inquery.dateTime.AddHours(Convert.ToInt32(Resource.GMT_5)); 
            var response = inquery.idInquery == 0 ? inquery.createInquery() : inquery.updateInquery();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Inquery);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(inquery.getInqueryById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.Inquery);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = inquery.deleteInqueryById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Inquery);
        }
    }
}