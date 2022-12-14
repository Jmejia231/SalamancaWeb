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
    public class DocumentIdentityType
    {
        [Display(Name = "Tipo de Documento Identidad:")]
        [Required]
        public int idDocumentIdentityType { get; set; }

        [Display(Name = "Nombre del Documento de Identidad:")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Abreviatura:")]
        [Required]
        [MaxLength(10)]
        public string abbreviation { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        //Implementacion de Metodos
        public Response<List<DocumentIdentityType>> getDocumentIdentityTypes()
        {
            var response = new Response<List<DocumentIdentityType>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DocumentIdentityTypeService service = adapter.Create<I_DocumentIdentityTypeService>();
                RestResponse<Response<List<DocumentIdentityType>>> responseServer = service.getDocumentIdentityTypes();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_COUNTRY, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<DocumentIdentityType> getDocumentIdentityTypeById(int id)
        {
            var response = new Response<DocumentIdentityType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DocumentIdentityTypeService service = adapter.Create<I_DocumentIdentityTypeService>();
                RestResponse<Response<DocumentIdentityType>> responseServer = service.getDocumentIdentityTypeById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DocumentIdentityType> createDocumentIdentityType()
        {
            var response = new Response<DocumentIdentityType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DocumentIdentityTypeService service = adapter.Create<I_DocumentIdentityTypeService>();
                RestResponse<Response<DocumentIdentityType>> responseServer = service.createDocumentIdentityType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DocumentIdentityType> updateDocumentIdentityType()
        {
            var response = new Response<DocumentIdentityType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DocumentIdentityTypeService service = adapter.Create<I_DocumentIdentityTypeService>();
                RestResponse<Response<DocumentIdentityType>> responseServer = service.updateDocumentIdentityType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DocumentIdentityType> deleteDocumentIdentityTypeById(int id)
        {
            var response = new Response<DocumentIdentityType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_DocumentIdentityTypeService service = adapter.Create<I_DocumentIdentityTypeService>();
                RestResponse<Response<DocumentIdentityType>> responseServer = service.deleteDocumentIdentityTypeById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeDocumentIdentityTypeItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione el Tipo de Documento de Identidad",
                Value = "",
                Selected = true,
                Disabled = true
            };

            //var documentIdentityTypes = getDocumentIdentityTypes().result.Where(x => x.status).OrderBy(x => x.name).ToList();
            var documentIdentityTypes = getDocumentIdentityTypes().result.OrderBy(x => x.name).ToList();

            List<SelectListItem> documentIdentityTypeItems = documentIdentityTypes.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.abbreviation : x.abbreviation + " (Inactivo)",
                    Value = x.idDocumentIdentityType.ToString(),
                    Disabled = !x.status,
                    Selected = false,
                };
            });
            //documentIdentityTypeItems.Insert(0, predetermine);
            return documentIdentityTypeItems;
        }
    }
}