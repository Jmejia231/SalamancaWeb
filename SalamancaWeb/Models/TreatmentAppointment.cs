using RestSharp;
using Retrofit.Net;
using SalamancaWeb.Resources;
using SalamancaWeb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalamancaWeb.Models
{
    public class TreatmentAppointment
    {
        [Display(Name = "Tratamiento Cita:")]
        [Required]
        public int idTreatmentAppointment { get; set; }

        [Display(Name = "Cita:")]
        [Required]
        public int idAppointment { get; set; }

        [Display(Name = "Tipo de Tratamiento:")]
        [Required]
        public int idTreatmentType { get; set; }

        [Display(Name = "Tiempo Estimado:")]
        [Required]
        public int timeEstimated { get; set; }

        public Appointment appointment { get; set; }

        public TreatmentType treatmentType { get; set; }

        //Implementacion de Metodos
        public Response<List<TreatmentAppointment>> getTreatmentAppointments()
        {
            var response = new Response<List<TreatmentAppointment>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentAppointmentService service = adapter.Create<I_TreatmentAppointmentService>();
                RestResponse<Response<List<TreatmentAppointment>>> responseServer = service.getTreatmentAppointments();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_APPOINTMENT_TREATMENT, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<TreatmentAppointment> getTreatmentAppointmentById(int id)
        {
            var response = new Response<TreatmentAppointment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentAppointmentService service = adapter.Create<I_TreatmentAppointmentService>();
                RestResponse<Response<TreatmentAppointment>> responseServer = service.getTreatmentAppointmentById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_APPOINTMENT_TREATMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentAppointment> createTreatmentAppointment()
        {
            var response = new Response<TreatmentAppointment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentAppointmentService service = adapter.Create<I_TreatmentAppointmentService>();
                RestResponse<Response<TreatmentAppointment>> responseServer = service.createTreatmentAppointment(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_APPOINTMENT_TREATMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentAppointment> updateTreatmentAppointment()
        {
            var response = new Response<TreatmentAppointment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentAppointmentService service = adapter.Create<I_TreatmentAppointmentService>();
                RestResponse<Response<TreatmentAppointment>> responseServer = service.updateTreatmentAppointment(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_APPOINTMENT_TREATMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TreatmentAppointment> deleteTreatmentAppointmentById(int id)
        {
            var response = new Response<TreatmentAppointment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_TreatmentAppointmentService service = adapter.Create<I_TreatmentAppointmentService>();
                RestResponse<Response<TreatmentAppointment>> responseServer = service.deleteTreatmentAppointmentById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_APPOINTMENT_TREATMENT, new List<string> { ex.ToString() });
            }
            return response;
        }
    }
}