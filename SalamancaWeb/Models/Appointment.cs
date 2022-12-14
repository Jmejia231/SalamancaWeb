using RestSharp;
using Retrofit.Net;
using SalamancaWeb.Resources;
using SalamancaWeb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalamancaWeb.Models
{
    public class Appointment
    {
        [Display(Name = "Cita:")]
        [Required]
        public int idAppointment { get; set; }

        [Display(Name = "Paciente:")]
        [Required]
        public int idPerson { get; set; }

        [Display(Name = "Motivo:")]
        [Required]
        [MaxLength(255)]
        public string motive { get; set; }

        [Display(Name = "Tipo de Estado Atencion:")]
        [Required]
        public int idAttentionStatus { get; set; }

        [Display(Name = "Fecha y Hora:")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dateTime { get; set; }


        public Person person { get; set; }


        public TreatmentStatus attentionStatus { get; set; }

        //Implementacion de Metodos
        public Response<List<Appointment>> getAppointments()
        {
            var response = new Response<List<Appointment>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AppointmentService service = adapter.Create<I_AppointmentService>();
                RestResponse<Response<List<Appointment>>> responseServer = service.getAppointments();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_APPOINTMENT, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<Appointment> getAppointmentById(int id)
        {
            var response = new Response<Appointment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AppointmentService service = adapter.Create<I_AppointmentService>();
                RestResponse<Response<Appointment>> responseServer = service.getAppointmentById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_APPOINTMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Appointment> createAppointment()
        {
            var response = new Response<Appointment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AppointmentService service = adapter.Create<I_AppointmentService>();
                RestResponse<Response<Appointment>> responseServer = service.createAppointment(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_APPOINTMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Appointment> updateAppointment()
        {
            var response = new Response<Appointment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AppointmentService service = adapter.Create<I_AppointmentService>();
                RestResponse<Response<Appointment>> responseServer = service.updateAppointment(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_APPOINTMENT, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Appointment> deleteAppointmentById(int id)
        {
            var response = new Response<Appointment>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_AppointmentService service = adapter.Create<I_AppointmentService>();
                RestResponse<Response<Appointment>> responseServer = service.deleteAppointmentById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_APPOINTMENT, new List<string> { ex.ToString() });
            }
            return response;
        }
    }
}