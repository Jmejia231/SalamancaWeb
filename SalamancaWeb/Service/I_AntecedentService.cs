using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamancaWeb.Service
{
    public interface I_AntecedentService
    {
        [Get("api/Antecedent")]
        RestResponse<Response<List<Antecedent>>> getAntecedents();

        [Get("api/Antecedent/{id}")]
        RestResponse<Response<Antecedent>> getAntecedentById([Path("id")] int id);

        [Post("api/Antecedent")]
        RestResponse<Response<Antecedent>> createAntecedent([Body] Antecedent antecedent);

        [Put("api/Antecedent")]
        RestResponse<Response<Antecedent>> updateAntecedent([Body] Antecedent antecedent);

        [Delete("api/Antecedent/{id}")]
        RestResponse<Response<Antecedent>> deleteAntecedentById([Path("id")] int id);
    }
}
