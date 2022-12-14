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
    public class Treatment
    {
        [Display(Name = "Tratamiento:")]
        [Required]
        public int idTreatment { get; set; }

        [Display(Name = "Consulta:")]
        [Required]
        public int idInquery { get; set; }

        [Display(Name = "Tipo de Tratamiento:")]
        [Required]
        public int idTreatmentType { get; set; }

        [Display(Name = "Precio S/.:")]
        [Required]
        public decimal priceSoles { get; set; }

        [Display(Name = "Tiempo Estimado:")]
        [Required]
        public int timeEstimated { get; set; }

        public Inquery inquery { get; set; }

        public TreatmentType treatmentType { get; set; }

        //Implementacion de Metodos
        public Response<List<Treatment>> getTreatments()
        {
            var response = new Response<List<Treatment>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentService service = adapter.Create<I_TreatmentService>();
                RestResponse<Response<List<Treatment>>> responseServer = service.getTreatments();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_TREATMENT, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<Treatment> getTreatmentById(int id)
        {
            var response = new Response<Treatment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentService service = adapter.Create<I_TreatmentService>();
                RestResponse<Response<Treatment>> responseServer = service.getTreatmentById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_TREATMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<List<Treatment>> createTreatment(List<Treatment> treatmentTypes)
        {
            var response = new Response<List<Treatment>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentService service = adapter.Create<I_TreatmentService>();
                RestResponse<Response<List<Treatment>>> responseServer = service.createTreatment(treatmentTypes);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_TREATMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Treatment> updateTreatment()
        {
            var response = new Response<Treatment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentService service = adapter.Create<I_TreatmentService>();
                RestResponse<Response<Treatment>> responseServer = service.updateTreatment(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_TREATMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Treatment> deleteTreatmentById(int id)
        {
            var response = new Response<Treatment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentService service = adapter.Create<I_TreatmentService>();
                RestResponse<Response<Treatment>> responseServer = service.deleteTreatmentById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_TREATMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeTreatmentItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione el Tratamiento",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var treatments = getTreatments().result.OrderBy(x => x.idTreatment).ToList();

            List<SelectListItem> treatmentItems = treatments.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.treatmentType.name.ToString() + " - " + x.inquery.person.names + " " + x.inquery.person.fatherLastname + " " + x.inquery.person.motherLastname,
                    Value = x.idTreatment.ToString(),
                    Selected = false,
                };
            });
            return treatmentItems;
        }
    }
}