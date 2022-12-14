using RestSharp;
using Retrofit.Net;
using SalamancaWeb.Resources;
using SalamancaWeb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalamancaWeb.Models
{
    public class SuffersFrom
    {
        [Display(Name = "Padecimiento:")]
        [Required]
        public int idSuffersFrom { get; set; }

        [Display(Name = "Tipo de Padecimiento:")]
        [Required]
        public int idDiseaseType { get; set; }

        [Display(Name = "Consulta:")]
        [Required]
        public int idInquery { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        public DiseaseType diseaseType { get; set; }

        public Inquery inquery { get; set; }

        //Implementacion de Metodos
        public Response<List<SuffersFrom>> getSuffersFrom()
        {
            var response = new Response<List<SuffersFrom>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_SuffersFromService service = adapter.Create<I_SuffersFromService>();
                RestResponse<Response<List<SuffersFrom>>> responseServer = service.getSuffersFrom();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_SUFFERS_FROM, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<SuffersFrom> getSuffersFromById(int id)
        {
            var response = new Response<SuffersFrom>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_SuffersFromService service = adapter.Create<I_SuffersFromService>();
                RestResponse<Response<SuffersFrom>> responseServer = service.getSuffersFromById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_SUFFERS_FROM, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<List<SuffersFrom>> createSuffersFrom(List<SuffersFrom> diseaseTypes)
        {
            var response = new Response<List<SuffersFrom>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_SuffersFromService service = adapter.Create<I_SuffersFromService>();
                RestResponse<Response<List<SuffersFrom>>> responseServer = service.createSuffersFrom(diseaseTypes);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_SUFFERS_FROM, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<SuffersFrom> updateSuffersFrom()
        {
            var response = new Response<SuffersFrom>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_SuffersFromService service = adapter.Create<I_SuffersFromService>();
                RestResponse<Response<SuffersFrom>> responseServer = service.updateSuffersFrom(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_SUFFERS_FROM, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<SuffersFrom> deleteSuffersFromById(int id)
        {
            var response = new Response<SuffersFrom>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_SuffersFromService service = adapter.Create<I_SuffersFromService>();
                RestResponse<Response<SuffersFrom>> responseServer = service.deleteSuffersFromById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_SUFFERS_FROM, new List<string> { ex.ToString() });
            }
            return response;
        }
    }
}