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
    public class AntecedentType
    {
        [Display(Name = "Tipo de Antecedente:")]
        [Required]
        public int idAntecedentType { get; set; }

        [Display(Name = "Nombre del Tipo de Antecedente:")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        //Implementacion de Metodos
        public Response<List<AntecedentType>> getAntecedentTypes()
        {
            var response = new Response<List<AntecedentType>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentTypeService service = adapter.Create<I_AntecedentTypeService>();
                RestResponse<Response<List<AntecedentType>>> responseServer = service.getAntecedentTypes();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_ANTECEDENT_TYPE, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<AntecedentType> getAntecedentTypeById(int id)
        {
            var response = new Response<AntecedentType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentTypeService service = adapter.Create<I_AntecedentTypeService>();
                RestResponse<Response<AntecedentType>> responseServer = service.getAntecedentTypeById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_ANTECEDENT_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<AntecedentType> createAntecedentType()
        {
            var response = new Response<AntecedentType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentTypeService service = adapter.Create<I_AntecedentTypeService>();
                RestResponse<Response<AntecedentType>> responseServer = service.createAntecedentType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_ANTECEDENT_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<AntecedentType> updateAntecedentType()
        {
            var response = new Response<AntecedentType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentTypeService service = adapter.Create<I_AntecedentTypeService>();
                RestResponse<Response<AntecedentType>> responseServer = service.updateAntecedentType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_ANTECEDENT_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<AntecedentType> deleteAntecedentTypeById(int id)
        {
            var response = new Response<AntecedentType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentTypeService service = adapter.Create<I_AntecedentTypeService>();
                RestResponse<Response<AntecedentType>> responseServer = service.deleteAntecedentTypeById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_ANTECEDENT_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeAntecedentTypeItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione el Tipo de Antecedente",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var antecedentTypes = getAntecedentTypes().result.OrderBy(x => x.name).ToList();

            List<SelectListItem> antecedentTypeItems = antecedentTypes.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.name : x.name + " (Inactivo)",
                    Value = x.idAntecedentType.ToString(),
                    Disabled = !x.status,
                    Selected = false,
                };
            });
            //documentIdentityTypeItems.Insert(0, predetermine);
            return antecedentTypeItems;
        }
    }
}