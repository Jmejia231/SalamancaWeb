using RestSharp;
using Retrofit.Net;
using SalamancaWeb.Resources;
using SalamancaWeb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalamancaWeb.Models {
    public class Antecedent {
        [Display(Name = "Antecedente:")]
        [Required]
        public int idAntecedent { get; set; }

        [Display(Name = "Consulta:")]
        [Required]
        public int idInquery { get; set; }

        [Display(Name = "Tipo de Antecedente:")]
        [Required]
        public int idAntecedentType { get; set; }

        [Display(Name = "Descripcion:")]
        [Required]
        [MaxLength(100)]
        public string description { get; set; }

        [Display(Name = "Fecha de Registro:")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dateRegistered { get; set; }

        public Inquery inquery { get; set; }

        public AntecedentType antecedentType { get; set; }

        //Implementacion de Metodos
        public Response<List<Antecedent>> getAntecedents() {
            var response = new Response<List<Antecedent>>();
            try {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentService service = adapter.Create<I_AntecedentService>();
                RestResponse<Response<List<Antecedent>>> responseServer = service.getAntecedents();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_ANTECEDENT, new List<string> { ex.Message.ToString() });

            }
            return response;
        }

        public Response<Antecedent> getAntecedentById(int id) {
            var response = new Response<Antecedent>();
            try {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentService service = adapter.Create<I_AntecedentService>();
                RestResponse<Response<Antecedent>> responseServer = service.getAntecedentById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_ANTECEDENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Antecedent> createAntecedent() {
            var response = new Response<Antecedent>();
            try {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentService service = adapter.Create<I_AntecedentService>();
                RestResponse<Response<Antecedent>> responseServer = service.createAntecedent(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_ANTECEDENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Antecedent> updateAntecedent() {
            var response = new Response<Antecedent>();
            try {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentService service = adapter.Create<I_AntecedentService>();
                RestResponse<Response<Antecedent>> responseServer = service.updateAntecedent(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_ANTECEDENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Antecedent> deleteAntecedentById(int id) {
            var response = new Response<Antecedent>();
            try {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AntecedentService service = adapter.Create<I_AntecedentService>();
                RestResponse<Response<Antecedent>> responseServer = service.deleteAntecedentById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_ANTECEDENT, new List<string> { ex.ToString() });
            }
            return response;
        }
    }
}