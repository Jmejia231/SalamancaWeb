using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_TreatmentAppointmentService {
        [Get("api/TreatmentAppointment")]
        RestResponse<Response<List<TreatmentAppointment>>> getTreatmentAppointments();

        [Get("api/TreatmentAppointment/{id}")]
        RestResponse<Response<TreatmentAppointment>> getTreatmentAppointmentById([Path("id")] int id);

        [Post("api/TreatmentAppointment")]
        RestResponse<Response<TreatmentAppointment>> createTreatmentAppointment([Body] TreatmentAppointment treatmentAppointment);

        [Put("api/TreatmentAppointment")]
        RestResponse<Response<TreatmentAppointment>> updateTreatmentAppointment([Body] TreatmentAppointment treatmentAppointment);

        [Delete("api/TreatmentAppointment/{id}")]
        RestResponse<Response<TreatmentAppointment>> deleteTreatmentAppointmentById([Path("id")] int id);
    }
}
