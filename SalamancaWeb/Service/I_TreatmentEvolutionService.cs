using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_TreatmentEvolutionService {
        [Get("api/TreatmentEvolution")]
        RestResponse<Response<List<TreatmentEvolution>>> getTreatmentEvolutions();

        [Get("api/TreatmentEvolution/{id}")]
        RestResponse<Response<TreatmentEvolution>> getTreatmentEvolutionById([Path("id")] int id);

        [Post("api/TreatmentEvolution")]
        RestResponse<Response<TreatmentEvolution>> createTreatmentEvolution([Body] TreatmentEvolution treatmentEvolution);

        [Put("api/TreatmentEvolution")]
        RestResponse<Response<TreatmentEvolution>> updateTreatmentEvolution([Body] TreatmentEvolution treatmentEvolution);

        [Delete("api/TreatmentEvolution/{id}")]
        RestResponse<Response<TreatmentEvolution>> deleteTreatmentEvolutionById([Path("id")] int id);
    }
}
