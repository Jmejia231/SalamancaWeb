using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class TreatmentTypeController : Controller
    {
        TreatmentType treatmentType = new TreatmentType();
        // GET: Treatment Type
        public ActionResult Index()
        {
            var response = treatmentType.getTreatmentTypes();
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
                return Redirect(HomeController.TreatmentType);
            }
            else
            {
                var response = treatmentType.getTreatmentTypeById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.TreatmentType);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new TreatmentType());
            }
            else
            {
                var response = treatmentType.getTreatmentTypeById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.TreatmentType);
                }
            }
        }

        public ActionResult Save(TreatmentType treatmentType)
        {
            var response = treatmentType.idTreatmentType == 0 ? treatmentType.createTreatmentType() : treatmentType.updateTreatmentType();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.TreatmentType);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(treatmentType.getTreatmentTypeById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.TreatmentType);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = treatmentType.deleteTreatmentTypeById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.TreatmentType);
        }
    }
}