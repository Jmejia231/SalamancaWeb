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
    public class TreatmentType
    {
        [Display(Name = "Tipo de Tratamiento:")]
        [Required]
        public int idTreatmentType { get; set; }

        [Display(Name = "Nombre del Tipo de Tratamiento:")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        //Implementacion de Metodos
        public Response<List<TreatmentType>> getTreatmentTypes()
        {
            var response = new Response<List<TreatmentType>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentTypeService service = adapter.Create<I_TreatmentTypeService>();
                RestResponse<Response<List<TreatmentType>>> responseServer = service.getTreatmentTypes();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_TREATMENT_TYPE, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<TreatmentType> getTreatmentTypeById(int id)
        {
            var response = new Response<TreatmentType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentTypeService service = adapter.Create<I_TreatmentTypeService>();
                RestResponse<Response<TreatmentType>> responseServer = service.getTreatmentTypeById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_TREATMENT_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentType> createTreatmentType()
        {
            var response = new Response<TreatmentType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentTypeService service = adapter.Create<I_TreatmentTypeService>();
                RestResponse<Response<TreatmentType>> responseServer = service.createTreatmentType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_TREATMENT_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentType> updateTreatmentType()
        {
            var response = new Response<TreatmentType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentTypeService service = adapter.Create<I_TreatmentTypeService>();
                RestResponse<Response<TreatmentType>> responseServer = service.updateTreatmentType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_TREATMENT_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentType> deleteTreatmentTypeById(int id)
        {
            var response = new Response<TreatmentType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentTypeService service = adapter.Create<I_TreatmentTypeService>();
                RestResponse<Response<TreatmentType>> responseServer = service.deleteTreatmentTypeById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_TREATMENT_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeTreatmentTypeItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione el Tipo de Tratamiento",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var treatmentTypes = getTreatmentTypes().result.OrderBy(x => x.name).ToList();

            List<SelectListItem> treatmentTypeItems = treatmentTypes.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.name : x.name + " (Inactivo)",
                    Value = x.idTreatmentType.ToString(),
                    Disabled = !x.status,
                    Selected = false,
                };
            });
            //documentIdentityTypeItems.Insert(0, predetermine);
            return treatmentTypeItems;
        }
    }
}