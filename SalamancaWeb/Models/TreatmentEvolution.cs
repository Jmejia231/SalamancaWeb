using RestSharp;
using Retrofit.Net;
using SalamancaWeb.Resources;
using SalamancaWeb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalamancaWeb.Models
{
    public class TreatmentEvolution
    {
        [Display(Name = "Detalle Evolucion:")]
        [Required]
        public int idTreatmentEvolution { get; set; }

        [Display(Name = "Detalle del Tratamiento:")]
        [Required]
        public int idTreatmentDetail { get; set; }

        [Display(Name = "Persona Encargada:")]
        [Required]
        public int idPersonIncharge { get; set; }

        [Display(Name = "Pieza:")]
        [Required]
        public int piece { get; set; }

        [Display(Name = "Procedimiento:")]
        [Required]
        [MaxLength(255)]
        public string process { get; set; }

        [Display(Name = "Fecha:")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }

        public TreatmentDetail treatmentDetail { get; set; }

        public Person personIncharge { get; set; }

        //Implementacion de Metodos
        public Response<List<TreatmentEvolution>> getTreatmentEvolutions()
        {
            var response = new Response<List<TreatmentEvolution>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentEvolutionService service = adapter.Create<I_TreatmentEvolutionService>();
                RestResponse<Response<List<TreatmentEvolution>>> responseServer = service.getTreatmentEvolutions();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_TREATMENT_EVOLUTION, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<TreatmentEvolution> getTreatmentEvolutionById(int id)
        {
            var response = new Response<TreatmentEvolution>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentEvolutionService service = adapter.Create<I_TreatmentEvolutionService>();
                RestResponse<Response<TreatmentEvolution>> responseServer = service.getTreatmentEvolutionById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_TREATMENT_EVOLUTION, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentEvolution> createTreatmentEvolution()
        {
            var response = new Response<TreatmentEvolution>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentEvolutionService service = adapter.Create<I_TreatmentEvolutionService>();
                RestResponse<Response<TreatmentEvolution>> responseServer = service.createTreatmentEvolution(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_TREATMENT_EVOLUTION, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentEvolution> updateTreatmentEvolution()
        {
            var response = new Response<TreatmentEvolution>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentEvolutionService service = adapter.Create<I_TreatmentEvolutionService>();
                RestResponse<Response<TreatmentEvolution>> responseServer = service.updateTreatmentEvolution(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_TREATMENT_EVOLUTION, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentEvolution> deleteTreatmentEvolutionById(int id)
        {
            var response = new Response<TreatmentEvolution>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentEvolutionService service = adapter.Create<I_TreatmentEvolutionService>();
                RestResponse<Response<TreatmentEvolution>> responseServer = service.deleteTreatmentEvolutionById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_TREATMENT_EVOLUTION, new List<string> { ex.ToString() });
            }
            return response;
        }
    }
}