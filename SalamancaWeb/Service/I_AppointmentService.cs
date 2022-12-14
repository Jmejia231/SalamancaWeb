using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_AppointmentService {
        [Get("api/Appointment")]
        RestResponse<Response<List<Appointment>>> getAppointments();

        [Get("api/Appointment/{id}")]
        RestResponse<Response<Appointment>> getAppointmentById([Path("id")] int id);

        [Post("api/Appointment")]
        RestResponse<Response<Appointment>> createAppointment([Body] Appointment appointment);

        [Put("api/Appointment")]
        RestResponse<Response<Appointment>> updateAppointment([Body] Appointment appointment);

        [Delete("api/Appointment/{id}")]
        RestResponse<Response<Appointment>> deleteAppointmentById([Path("id")] int id);
    }
}
