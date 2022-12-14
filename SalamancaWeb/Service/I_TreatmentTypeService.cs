using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_TreatmentTypeService {
        [Get("api/TreatmentType")]
        RestResponse<Response<List<TreatmentType>>> getTreatmentTypes();

        [Get("api/TreatmentType/{id}")]
        RestResponse<Response<TreatmentType>> getTreatmentTypeById([Path("id")] int id);

        [Post("api/TreatmentType")]
        RestResponse<Response<TreatmentType>> createTreatmentType([Body] TreatmentType treatmentType);

        [Put("api/TreatmentType")]
        RestResponse<Response<TreatmentType>> updateTreatmentType([Body] TreatmentType treatmentType);

        [Delete("api/TreatmentType/{id}")]
        RestResponse<Response<TreatmentType>> deleteTreatmentTypeById([Path("id")] int id);
    }
}
