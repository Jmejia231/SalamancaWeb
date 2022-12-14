using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class AntecedentController : Controller
    {
        Person person = new Person();
        Inquery inquery = new Inquery();
        Antecedent antecedent = new Antecedent();
        AntecedentType antecedentType = new AntecedentType();
        // GET: City
        public ActionResult Index()
        {
            var response = antecedent.getAntecedents();
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
                return Redirect(HomeController.Antecedent);
            }
            else
            {
                var response = antecedent.getAntecedentById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Antecedent);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            ViewBag.inqueries = inquery.initializeInqueryItems();
            ViewBag.antecedentTypes = antecedentType.initializeAntecedentTypeItems();
            if(id == 0)
            {
                return View(new Antecedent());
            }
            else
            {
                var response = antecedent.getAntecedentById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Antecedent);
                }
            }
        }

        public ActionResult Save(Antecedent antecedent)
        {
            //Asignar los Valores a los ID
            antecedent.idInquery = antecedent.inquery.idInquery;
            antecedent.idAntecedentType = antecedent.antecedentType.idAntecedentType;
            //Anular los Objetos(Paises) = NULL
            antecedent.inquery = null;
            antecedent.antecedentType = null;
            //normailito aquiles
            antecedent.dateRegistered = antecedent.idAntecedent == 0 ? DateTime.UtcNow.AddHours(Convert.ToInt32(Resource.GMT_5)) : antecedent.dateRegistered.AddHours(Convert.ToInt32(Resource.GMT_5));
            var response = antecedent.idAntecedent == 0 ? antecedent.createAntecedent() : antecedent.updateAntecedent();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Antecedent);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(antecedent.getAntecedentById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.Antecedent);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = antecedent.deleteAntecedentById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Antecedent);
        }
    }
}