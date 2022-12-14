using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_TreatmentStatusService {
        [Get("api/TreatmentStatus")]
        RestResponse<Response<List<TreatmentStatus>>> getTreatmentStatuses();

        [Get("api/TreatmentStatus/{id}")]
        RestResponse<Response<TreatmentStatus>> getTreatmentStatusById([Path("id")] int id);

        [Post("api/TreatmentStatus")]
        RestResponse<Response<TreatmentStatus>> createTreatmentStatus([Body] TreatmentStatus treatmentStatus);

        [Put("api/TreatmentStatus")]
        RestResponse<Response<TreatmentStatus>> updateTreatmentStatus([Body] TreatmentStatus treatmentStatus);

        [Delete("api/TreatmentStatus/{id}")]
        RestResponse<Response<TreatmentStatus>> deleteTreatmentStatusById([Path("id")] int id);
    }
}
