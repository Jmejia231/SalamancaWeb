using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_GenderService {
        [Get("api/Gender")]
        RestResponse<Response<List<Gender>>> getGenders();

        [Get("api/Gender/{id}")]
        RestResponse<Response<Gender>> getGenderById([Path("id")] int id);

        [Post("api/Gender")]
        RestResponse<Response<Gender>> createGender([Body] Gender gender);

        [Put("api/Gender")]
        RestResponse<Response<Gender>> updateGender([Body] Gender gender);

        [Delete("api/Gender/{id}")]
        RestResponse<Response<Gender>> deleteGenderById([Path("id")] int id);
    }
}
