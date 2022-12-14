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
    public class DiseaseType
    {
        [Display(Name = "Tipo de Padecimiento:")]
        [Required]
        public int idDiseaseType { get; set; }

        [Display(Name = "Nombre de Padecimiento:")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        //Implementacion de Metodos
        public Response<List<DiseaseType>> getDiseaseTypes()
        {
            var response = new Response<List<DiseaseType>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DiseaseTypeService service = adapter.Create<I_DiseaseTypeService>();
                RestResponse<Response<List<DiseaseType>>> responseServer = service.getDiseaseTypes();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_DISEASE_TYPE, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<DiseaseType> getDiseaseTypeById(int id)
        {
            var response = new Response<DiseaseType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DiseaseTypeService service = adapter.Create<I_DiseaseTypeService>();
                RestResponse<Response<DiseaseType>> responseServer = service.getDiseaseTypeById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_DISEASE_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DiseaseType> createDiseaseType()
        {
            var response = new Response<DiseaseType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DiseaseTypeService service = adapter.Create<I_DiseaseTypeService>();
                RestResponse<Response<DiseaseType>> responseServer = service.createDiseaseType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_DISEASE_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DiseaseType> updateDiseaseType()
        {
            var response = new Response<DiseaseType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DiseaseTypeService service = adapter.Create<I_DiseaseTypeService>();
                RestResponse<Response<DiseaseType>> responseServer = service.updateDiseaseType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_DISEASE_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DiseaseType> deleteDiseaseTypeById(int id)
        {
            var response = new Response<DiseaseType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DiseaseTypeService service = adapter.Create<I_DiseaseTypeService>();
                RestResponse<Response<DiseaseType>> responseServer = service.deleteDiseaseTypeById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_DISEASE_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeDiseaseTypeItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione el Tipo de Padecimiento",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var diseaseTypes = getDiseaseTypes().result.OrderBy(x => x.name).ToList();

            List<SelectListItem> diseaseTypeItems = diseaseTypes.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.name : x.name + " (Inactivo)",
                    Value = x.idDiseaseType.ToString(),
                    Disabled = !x.status,
                    Selected = false,
                };
            });
            //documentIdentityTypeItems.Insert(0, predetermine);
            return diseaseTypeItems;
        }
    }
}