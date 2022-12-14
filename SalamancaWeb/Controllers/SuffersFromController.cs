using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class SuffersFromController : Controller
    {
        DiseaseType diseaseType = new DiseaseType();
        Inquery inquery = new Inquery();
        SuffersFrom suffersFrom = new SuffersFrom();
        // GET: SuffersFrom
        public ActionResult Index()
        {
            var response = suffersFrom.getSuffersFrom();
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
                return Redirect(HomeController.SuffersFrom);
            }
            else
            {
                var response = suffersFrom.getSuffersFromById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.SuffersFrom);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            ViewBag.inqueries = inquery.initializeInqueryItems();
            ViewBag.diseaseTypes = diseaseType.initializeDiseaseTypeItems();
            if(id == 0)
            {
                return View(new SuffersFrom());
            }
            else
            {
                var response = suffersFrom.getSuffersFromById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.SuffersFrom);
                }
            }
        }

        public ActionResult Save(SuffersFrom suffersFrom, string[] diseaseType_idDiseaseTypes)
        {
            //Asignar los Valores a los ID
            suffersFrom.idInquery = suffersFrom.inquery.idInquery;
            //Anular los Objetos(Paises) = NULL
            suffersFrom.inquery = null;
            //solo si se edita 
            if(suffersFrom.idSuffersFrom != 0)
            {
                suffersFrom.idDiseaseType = suffersFrom.diseaseType.idDiseaseType;
                suffersFrom.diseaseType = null;
                var response = suffersFrom.updateSuffersFrom();
                UtilityClass.constructAlert(response.success, response.displayMessage);
            }

            //aca es para varios tipos de padecimientos
            var diseaseTypes = new List<SuffersFrom>();
            if(diseaseType_idDiseaseTypes != null)
            {
                foreach(var diseaseType in diseaseType_idDiseaseTypes)
                {
                    diseaseTypes.Add(new SuffersFrom()
                    {
                        idInquery = suffersFrom.idInquery,
                        idDiseaseType = Convert.ToInt32(diseaseType),
                        status = suffersFrom.status
                    });
                }
                var response = suffersFrom.createSuffersFrom(diseaseTypes);
                UtilityClass.constructAlert(response.success, response.displayMessage);
            }

            return Redirect(HomeController.SuffersFrom);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(suffersFrom.getSuffersFromById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.SuffersFrom);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = suffersFrom.deleteSuffersFromById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.SuffersFrom);
        }
    }
}