using SalamancaWeb.Models;
using SalamancaWeb.Resources;
using SalamancaWeb.Utility;
using System;
using System.Web.Mvc;

namespace SalamancaWeb.Controllers
{
    public class AttentionStatusController : Controller
    {
        AttentionStatus attentionStatus = new AttentionStatus();
        // GET: Country
        public ActionResult Index()
        {
            var response = attentionStatus.getAttentionStatuses();
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
                return Redirect(HomeController.AttentionStatus);
            }
            else
            {
                var response = attentionStatus.getAttentionStatusById(Convert.ToInt32(id));
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.AttentionStatus);
                }
            }
        }

        public ActionResult AddEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new AttentionStatus());
            }
            else
            {
                var response = attentionStatus.getAttentionStatusById(id);
                if(response.result != null)
                {
                    return View(response.result);
                }
                else
                {
                    return Redirect(HomeController.AttentionStatus);
                }
            }
        }

        public ActionResult Save(AttentionStatus attentionStatusType)
        {
            var response = attentionStatusType.idAttentionStatus == 0 ? attentionStatusType.createAttentionStatus() : attentionStatusType.updateAttentionStatus();
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.AttentionStatus);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return View(attentionStatus.getAttentionStatusById(Convert.ToInt32(id)).result);
            }
            else
            {
                return Redirect(HomeController.AttentionStatus);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = attentionStatus.deleteAttentionStatusById(id);
            UtilityClass.constructAlert(response.success, response.displayMessage);
            return Redirect(HomeController.AttentionStatus);
        }
    }
}