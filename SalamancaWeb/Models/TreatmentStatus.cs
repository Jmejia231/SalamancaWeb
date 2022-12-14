using RestSharp;
using Retrofit.Net;
using SalamancaWeb.Resources;
using SalamancaWeb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace SalamancaWeb.Models
{
    public class TreatmentStatus
    {
        [Display(Name = "Estado Tratamiento:")]
        [Required]
        public int idTreatmentStatus { get; set; }

        [Display(Name = "Estado de Tratamiento:")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Orden:")]
        [Required]
        public int priority { get; set; }

        [Display(Name = "Color:")]
        [Required]
        [MaxLength(10)]
        public string color { get; set; }

        //Implementacion de Metodos
        public Response<List<TreatmentStatus>> getTreatmentStatuses()
        {
            var response = new Response<List<TreatmentStatus>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentStatusService service = adapter.Create<I_TreatmentStatusService>();
                RestResponse<Response<List<TreatmentStatus>>> responseServer = service.getTreatmentStatuses();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_TREATMENT_STATUS_TYPE, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<TreatmentStatus> getTreatmentStatusById(int id)
        {
            var response = new Response<TreatmentStatus>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentStatusService service = adapter.Create<I_TreatmentStatusService>();
                RestResponse<Response<TreatmentStatus>> responseServer = service.getTreatmentStatusById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_TREATMENT_STATUS_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentStatus> createTreatmentStatus()
        {
            var response = new Response<TreatmentStatus>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentStatusService service = adapter.Create<I_TreatmentStatusService>();
                RestResponse<Response<TreatmentStatus>> responseServer = service.createTreatmentStatus(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_TREATMENT_STATUS_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentStatus> updateTreatmentStatus()
        {
            var response = new Response<TreatmentStatus>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentStatusService service = adapter.Create<I_TreatmentStatusService>();
                RestResponse<Response<TreatmentStatus>> responseServer = service.updateTreatmentStatus(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_TREATMENT_STATUS_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentStatus> deleteTreatmentStatusById(int id)
        {
            var response = new Response<TreatmentStatus>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentStatusService service = adapter.Create<I_TreatmentStatusService>();
                RestResponse<Response<TreatmentStatus>> responseServer = service.deleteTreatmentStatusById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_TREATMENT_STATUS_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeTreatmentStatusItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione un Estado de Tratamiento",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var treatmentStatuses = getTreatmentStatuses().result.OrderBy(x => x.priority).ToList();

            List<SelectListItem> treatmentStatusesItems = treatmentStatuses.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.name,
                    Value = x.idTreatmentStatus.ToString(),
                    Selected = false,
                };
            });
            //countryItems.Insert(0, predetermine);
            return treatmentStatusesItems;
        }
    }
}