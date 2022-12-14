using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class TreatmentController : Controller
    {
        TreatmentType treatmentType = new TreatmentType();
        Inquery inquery = new Inquery();
        Treatment treatment = new Treatment();
        // GET: SuffersFrom
        public ActionResult Index()
        {
            var response = treatment.getTreatments();
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
                return Redirect(HomeController.Treatment);
            }
            else
            {
                var response = treatment.getTreatmentById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Treatment);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            ViewBag.inqueries = inquery.initializeInqueryItems();
            ViewBag.treatmentTypes = treatmentType.initializeTreatmentTypeItems();
            if(id == 0)
            {
                return View(new Treatment());
            }
            else
            {
                var response = treatment.getTreatmentById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.Treatment);
                }
            }
        }

        public ActionResult Save(Treatment treatment, string[] treatmentType_idTreatmentTypes)
        {
            //Asignar los Valores a los ID
            treatment.idInquery = treatment.inquery.idInquery;
            //Anular los Objetos(Paises) = NULL
            treatment.inquery = null;
            //solo si se edita 
            if(treatment.idTreatment != 0)
            {
                treatment.idTreatmentType = treatment.treatmentType.idTreatmentType;
                treatment.treatmentType = null;
                var response = treatment.updateTreatment();
                UtilityClass.constructAlert(response.success, response.displayMessage);
            }

            //aca es para varios tipos de tratamientos
            var treatmentTypes = new List<Treatment>();
            if(treatmentType_idTreatmentTypes != null)
            {
                foreach(var treatmentType in treatmentType_idTreatmentTypes)
                {
                    treatmentTypes.Add(new Treatment()
                    {
                        idInquery = treatment.idInquery,
                        idTreatmentType = Convert.ToInt32(treatmentType),
                        priceSoles = treatment.priceSoles,
                        timeEstimated = treatment.timeEstimated
                    });
                }
                var response = treatment.createTreatment(treatmentTypes);
                UtilityClass.constructAlert(response.success, response.displayMessage);
            }

            return Redirect(HomeController.Treatment);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(treatment.getTreatmentById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.Treatment);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = treatment.deleteTreatmentById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.Treatment);
        }
    }
}