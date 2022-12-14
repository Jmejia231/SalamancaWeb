using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class AntecedentTypeController : Controller
    {
        AntecedentType antecedentType = new AntecedentType();
        // GET: Antecedent Type
        public ActionResult Index()
        {
            var response = antecedentType.getAntecedentTypes();
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
                return Redirect(HomeController.AntecedentType);
            }
            else
            {
                var response = antecedentType.getAntecedentTypeById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.AntecedentType);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new AntecedentType());
            }
            else
            {
                var response = antecedentType.getAntecedentTypeById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.AntecedentType);
                }
            }
        }

        public ActionResult Save(AntecedentType antecedentType)
        {
            var response = antecedentType.idAntecedentType == 0 ? antecedentType.createAntecedentType() : antecedentType.updateAntecedentType();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.AntecedentType);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(antecedentType.getAntecedentTypeById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.AntecedentType);
            }
        }
    }
}