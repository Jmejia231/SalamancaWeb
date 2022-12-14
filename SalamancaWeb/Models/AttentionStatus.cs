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
    public class AttentionStatus
    {
        [Display(Name = "Tipo de Estado Atencion:")]
        [Required]
        public int idAttentionStatus { get; set; }

        [Display(Name = "Estado de Atencion:")]
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
        public Response<List<AttentionStatus>> getAttentionStatuses()
        {
            var response = new Response<List<AttentionStatus>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AttentionStatusService service = adapter.Create<I_AttentionStatusService>();
                RestResponse<Response<List<AttentionStatus>>> responseServer = service.getAttentionStatuses();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_ATTENTION_STATUS_TYPE, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<AttentionStatus> getAttentionStatusById(int id)
        {
            var response = new Response<AttentionStatus>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AttentionStatusService service = adapter.Create<I_AttentionStatusService>();
                RestResponse<Response<AttentionStatus>> responseServer = service.getAttentionStatusById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_ATTENTION_STATUS_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<AttentionStatus> createAttentionStatus()
        {
            var response = new Response<AttentionStatus>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AttentionStatusService service = adapter.Create<I_AttentionStatusService>();
                RestResponse<Response<AttentionStatus>> responseServer = service.createAttentionStatus(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_ATTENTION_STATUS_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<AttentionStatus> updateAttentionStatus()
        {
            var response = new Response<AttentionStatus>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AttentionStatusService service = adapter.Create<I_AttentionStatusService>();
                RestResponse<Response<AttentionStatus>> responseServer = service.updateAttentionStatus(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_ATTENTION_STATUS_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<AttentionStatus> deleteAttentionStatusById(int id)
        {
            var response = new Response<AttentionStatus>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AttentionStatusService service = adapter.Create<I_AttentionStatusService>();
                RestResponse<Response<AttentionStatus>> responseServer = service.deleteAttentionStatusById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_ATTENTION_STATUS_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeAttentionStatusItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione un Estado de Atencion",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var attentionStatuses = getAttentionStatuses().result.OrderBy(x => x.priority).ToList();

            List<SelectListItem> attentionStatusItems = attentionStatuses.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.name,
                    Value = x.idAttentionStatus.ToString(),
                    Selected = false,
                };
            });
            //countryItems.Insert(0, predetermine);
            return attentionStatusItems;
        }
    }
}