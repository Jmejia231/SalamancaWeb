using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_TreatmentDetailService {
        [Get("api/TreatmentDetail")]
        RestResponse<Response<List<TreatmentDetail>>> getTreatmentDetails();

        [Get("api/TreatmentDetail/{id}")]
        RestResponse<Response<TreatmentDetail>> getTreatmentDetailById([Path("id")] int id);

        [Post("api/TreatmentDetail")]
        RestResponse<Response<TreatmentDetail>> createTreatmentDetail([Body] TreatmentDetail treatmentDetail);

        [Put("api/TreatmentDetail")]
        RestResponse<Response<TreatmentDetail>> updateTreatmentDetail([Body] TreatmentDetail treatmentDetail);

        [Delete("api/TreatmentDetail/{id}")]
        RestResponse<Response<TreatmentDetail>> deleteTreatmentDetailById([Path("id")] int id);
    }
}
