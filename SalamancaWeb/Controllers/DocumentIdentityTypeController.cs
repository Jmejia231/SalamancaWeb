using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class DocumentIdentityTypeController : Controller
    {
        DocumentIdentityType documentIdentityType = new DocumentIdentityType();
        // GET: Document Identity Type
        public ActionResult Index()
        {
            var response = documentIdentityType.getDocumentIdentityTypes();
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
                return Redirect(HomeController.DocumentIdentityType);
            }
            else
            {
                var response = documentIdentityType.getDocumentIdentityTypeById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.DocumentIdentityType);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new DocumentIdentityType());
            }
            else
            {
                var response = documentIdentityType.getDocumentIdentityTypeById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.DocumentIdentityType);
                }
            }
        }

        public ActionResult Save(DocumentIdentityType documentIdentityType)
        {
            var response = documentIdentityType.idDocumentIdentityType == 0 ? documentIdentityType.createDocumentIdentityType() : documentIdentityType.updateDocumentIdentityType();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.DocumentIdentityType);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(documentIdentityType.getDocumentIdentityTypeById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.DocumentIdentityType);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = documentIdentityType.deleteDocumentIdentityTypeById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.DocumentIdentityType);
        }
    }
}