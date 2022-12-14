using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class DiseaseTypeController : Controller
    {
        DiseaseType diseaseType = new DiseaseType();
        // GET: Disease Type
        public ActionResult Index()
        {
            var response = diseaseType.getDiseaseTypes();
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
                return Redirect(HomeController.DiseaseType);
            }
            else
            {
                var response = diseaseType.getDiseaseTypeById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.DiseaseType);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new DiseaseType());
            }
            else
            {
                var response = diseaseType.getDiseaseTypeById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.DiseaseType);
                }
            }
        }

        public ActionResult Save(DiseaseType diseaseType)
        {
            var response = diseaseType.idDiseaseType == 0 ? diseaseType.createDiseaseType() : diseaseType.updateDiseaseType();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.DiseaseType);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(diseaseType.getDiseaseTypeById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.DiseaseType);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = diseaseType.deleteDiseaseTypeById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.DiseaseType);
        }
    }
}