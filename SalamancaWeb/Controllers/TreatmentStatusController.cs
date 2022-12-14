using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class TreatmentStatusController : Controller
    {
        TreatmentStatus treatmentStatusType = new TreatmentStatus();
        // GET: Treatment Status Type
        public ActionResult Index()
        {
            var response = treatmentStatusType.getTreatmentStatuses();
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
                return Redirect(HomeController.TreatmentStatus);
            }
            else
            {
                var response = treatmentStatusType.getTreatmentStatusById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.TreatmentStatus);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new TreatmentStatus());
            }
            else
            {
                var response = treatmentStatusType.getTreatmentStatusById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.TreatmentStatus);
                }
            }
        }

        public ActionResult Save(TreatmentStatus treatmentStatusType)
        {
            var response = treatmentStatusType.idTreatmentStatus == 0 ? treatmentStatusType.createTreatmentStatus() : treatmentStatusType.updateTreatmentStatus();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.TreatmentStatus);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(treatmentStatusType.getTreatmentStatusById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.TreatmentStatus);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = treatmentStatusType.deleteTreatmentStatusById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.TreatmentStatus);
        }
    }
}