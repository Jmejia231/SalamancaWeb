using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System.Collections.Generic;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class TreatmentDetailController : Controller
    {
        TreatmentStatus treatmentStatus = new TreatmentStatus();
        Inquery inquery = new Inquery();
        Treatment treatment = new Treatment();
        TreatmentDetail treatmentDetail = new TreatmentDetail();
        // GET: SuffersFrom
        public ActionResult Index()
        {
            var response = treatmentDetail.getTreatmentDetails();
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
                return Redirect(HomeController.TreatmentDetail);
            }
            else
            {
                var response = treatmentDetail.getTreatmentDetailById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.TreatmentDetail);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            ViewBag.treatments = treatment.initializeTreatmentItems();
            ViewBag.treatmentStatuses = treatmentStatus.initializeTreatmentStatusItems();
            if(id == 0)
            {
                return View(new TreatmentDetail());
            }
            else
            {
                var response = treatmentDetail.getTreatmentDetailById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.TreatmentDetail);
                }
            }
        }

        public ActionResult Save(TreatmentDetail treatmentDetail)
        {
            //Asignar los Valores a los ID
            treatmentDetail.idTreatment = treatmentDetail.treatment.idTreatment;
            treatmentDetail.idTreatmentStatus = treatmentDetail.treatmentStatus.idTreatmentStatus;
            //Anular los Objetos(Paises) = NULL
            treatmentDetail.treatment = null;
            treatmentDetail.treatmentStatus = null;
            //normailito aquiles
            treatmentDetail.date = treatmentDetail.idTreatmentDetail == 0 ? DateTime.UtcNow.AddHours(Convert.ToInt32(Resource.GMT_5)) : treatmentDetail.date.AddHours(Convert.ToInt32(Resource.GMT_5));
            var response = treatmentDetail.idTreatmentDetail == 0 ? treatmentDetail.createTreatmentDetail() : treatmentDetail.updateTreatmentDetail();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.TreatmentDetail);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(treatmentDetail.getTreatmentDetailById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.TreatmentDetail);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = treatmentDetail.deleteTreatmentDetailById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.TreatmentDetail);
        }
    }
}