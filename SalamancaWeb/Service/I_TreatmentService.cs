using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service
{
    public interface I_TreatmentService
    {
        [Get("api/Treatment")]
        RestResponse<Response<List<Treatment>>> getTreatments();

        [Get("api/Treatment/{id}")]
        RestResponse<Response<Treatment>> getTreatmentById([Path("id")] int id);

        [Post("api/Treatment")]
        RestResponse<Response<Treatment>> createTreatment([Body] Treatment treatment);
        
        [Post("api/Treatment/list")]
        RestResponse<Response<List<Treatment>>> createTreatment([Body] List<Treatment> treatmentTypes);

        [Put("api/Treatment")]
        RestResponse<Response<Treatment>> updateTreatment([Body] Treatment treatment);

        [Delete("api/Treatment/{id}")]
        RestResponse<Response<Treatment>> deleteTreatmentById([Path("id")] int id);
    }
}
