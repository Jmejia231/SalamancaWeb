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
    public class Inquery
    {
        [Display(Name = "Consulta:")]
        [Required]
        public int idInquery { get; set; }

        [Display(Name = "Paciente:")]
        [Required]
        public int idPerson { get; set; }

        [Display(Name = "Fecha y Hora:")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dateTime { get; set; }

        [Display(Name = "Motivo:")]
        [Required]
        [MaxLength(255)]
        public string motive { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        public Person person { get; set; }

        //Implementacion de Metodos
        public Response<List<Inquery>> getInqueries()
        {
            var response = new Response<List<Inquery>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_InqueryService service = adapter.Create<I_InqueryService>();
                RestResponse<Response<List<Inquery>>> responseServer = service.getInqueries();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_INQUERY, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<Inquery> getInqueryById(int id)
        {
            var response = new Response<Inquery>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_InqueryService service = adapter.Create<I_InqueryService>();
                RestResponse<Response<Inquery>> responseServer = service.getInqueryById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_INQUERY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Inquery> createInquery()
        {
            var response = new Response<Inquery>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_InqueryService service = adapter.Create<I_InqueryService>();
                RestResponse<Response<Inquery>> responseServer = service.createInquery(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_INQUERY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Inquery> updateInquery()
        {
            var response = new Response<Inquery>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_InqueryService service = adapter.Create<I_InqueryService>();
                RestResponse<Response<Inquery>> responseServer = service.updateInquery(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_INQUERY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Inquery> deleteInqueryById(int id)
        {
            var response = new Response<Inquery>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_InqueryService service = adapter.Create<I_InqueryService>();
                RestResponse<Response<Inquery>> responseServer = service.deleteInqueryById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_INQUERY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeInqueryItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione la Consulta",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var inqueries = getInqueries().result.OrderByDescending(x => x.dateTime).ToList();

            List<SelectListGroup> groups = inqueries.Select(x => new
            {
                date = x.dateTime.ToString("dd/MM/yyyy"),
            }).Distinct().ToList().ConvertAll(x =>
            {
                return new SelectListGroup()
                {
                    Name = x.date.ToString(),
                };
            });

            List<SelectListItem> inqueryItems = inqueries.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.person.names + " " + x.person.fatherLastname + " " + x.person.motherLastname : x.person.names + " " + x.person.fatherLastname + " " + x.person.motherLastname + " (Inactivo)",
                    Value = x.idInquery.ToString(),
                    Disabled = !x.status,
                    Group = groups.Find(y => y.Name.Equals(x.dateTime.ToString("dd/MM/yyyy"))),
                    Selected = false,
                };
            });
            //inqueryItems.Insert(0, predetermine);
            return inqueryItems;
        }
    }
}