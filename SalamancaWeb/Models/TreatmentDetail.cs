using RestSharp;
using Retrofit.Net;
using SalamancaWeb.Resources;
using SalamancaWeb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalamancaWeb.Models
{
    public class TreatmentDetail
    {
        [Display(Name = "Detalle Tratamiento:")]
        [Required]
        public int idTreatmentDetail { get; set; }

        [Display(Name = "Estado del Tratamiento:")]
        [Required]
        public int idTreatmentStatus { get; set; }

        [Display(Name = "Tratamiento:")]
        [Required]
        public int idTreatment { get; set; }

        [Display(Name = "Fecha:")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }

        [Display(Name = "Pieza:")]
        [Required]
        public int piece { get; set; }

        [Display(Name = "Debe:")]
        [Required]
        public decimal owns { get; set; }

        [Display(Name = "Haber:")]
        [Required]
        public decimal credit { get; set; }

        [Display(Name = "Saldo:")]
        [Required]
        public decimal balance { get; set; }

        public TreatmentStatus treatmentStatus { get; set; }

        public Treatment treatment { get; set; }

        //Implementacion de Metodos
        public Response<List<TreatmentDetail>> getTreatmentDetails()
        {
            var response = new Response<List<TreatmentDetail>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentDetailService service = adapter.Create<I_TreatmentDetailService>();
                RestResponse<Response<List<TreatmentDetail>>> responseServer = service.getTreatmentDetails();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_TREATMENT_DETAIL, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<TreatmentDetail> getTreatmentDetailById(int id)
        {
            var response = new Response<TreatmentDetail>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentDetailService service = adapter.Create<I_TreatmentDetailService>();
                RestResponse<Response<TreatmentDetail>> responseServer = service.getTreatmentDetailById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_TREATMENT_DETAIL, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentDetail> createTreatmentDetail()
        {
            var response = new Response<TreatmentDetail>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentDetailService service = adapter.Create<I_TreatmentDetailService>();
                RestResponse<Response<TreatmentDetail>> responseServer = service.createTreatmentDetail(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_TREATMENT_DETAIL, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentDetail> updateTreatmentDetail()
        {
            var response = new Response<TreatmentDetail>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentDetailService service = adapter.Create<I_TreatmentDetailService>();
                RestResponse<Response<TreatmentDetail>> responseServer = service.updateTreatmentDetail(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_TREATMENT_DETAIL, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentDetail> deleteTreatmentDetailById(int id)
        {
            var response = new Response<TreatmentDetail>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentDetailService service = adapter.Create<I_TreatmentDetailService>();
                RestResponse<Response<TreatmentDetail>> responseServer = service.deleteTreatmentDetailById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_TREATMENT_DETAIL, new List<string> { ex.ToString() });
            }
            return response;
        }
    }
}