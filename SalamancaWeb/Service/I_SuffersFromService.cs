using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service
{
    public interface I_SuffersFromService
    {
        [Get("api/SuffersFrom")]
        RestResponse<Response<List<SuffersFrom>>> getSuffersFrom();

        [Get("api/SuffersFrom/{id}")]
        RestResponse<Response<SuffersFrom>> getSuffersFromById([Path("id")] int id);

        [Post("api/SuffersFrom")]
        RestResponse<Response<SuffersFrom>> createSuffersFrom([Body] SuffersFrom suffersFrom);

        [Post("api/SuffersFrom/list")]
        RestResponse<Response<List<SuffersFrom>>> createSuffersFrom([Body] List<SuffersFrom> diseaseTypes);

        [Put("api/SuffersFrom")]
        RestResponse<Response<SuffersFrom>> updateSuffersFrom([Body] SuffersFrom suffersFrom);

        [Delete("api/SuffersFrom/{id}")]
        RestResponse<Response<SuffersFrom>> deleteSuffersFromById([Path("id")] int id);
    }
}
