using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_AntecedentTypeService {
        [Get("api/AntecedentType")]
        RestResponse<Response<List<AntecedentType>>> getAntecedentTypes();

        [Get("api/AntecedentType/{id}")]
        RestResponse<Response<AntecedentType>> getAntecedentTypeById([Path("id")] int id);

        [Post("api/AntecedentType")]
        RestResponse<Response<AntecedentType>> createAntecedentType([Body] AntecedentType antecedentType);

        [Put("api/AntecedentType")]
        RestResponse<Response<AntecedentType>> updateAntecedentType([Body] AntecedentType antecedentType);

        [Delete("api/AntecedentType/{id}")]
        RestResponse<Response<AntecedentType>> deleteAntecedentTypeById([Path("id")] int id);
    }
}
