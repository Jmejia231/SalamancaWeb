using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service
{
    public interface I_InqueryService
    {
        [Get("api/Inquery")]
        RestResponse<Response<List<Inquery>>> getInqueries();

        [Get("api/Inquery/{id}")]
        RestResponse<Response<Inquery>> getInqueryById([Path("id")] int id);

        [Post("api/Inquery")]
        RestResponse<Response<Inquery>> createInquery([Body] Inquery inquery);

        [Put("api/Inquery")]
        RestResponse<Response<Inquery>> updateInquery([Body] Inquery inquery);

        [Delete("api/Inquery/{id}")]
        RestResponse<Response<Inquery>> deleteInqueryById([Path("id")] int id);
    }
}
