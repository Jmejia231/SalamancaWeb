using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_UserTypeService {
        [Get("api/UserType")]
        RestResponse<Response<List<UserType>>> getUserTypes();

        [Get("api/UserType/{id}")]
        RestResponse<Response<UserType>> getUserTypeById([Path("id")] int id);

        [Post("api/UserType")]
        RestResponse<Response<UserType>> createUserType([Body] UserType userType);

        [Put("api/UserType")]
        RestResponse<Response<UserType>> updateUserType([Body] UserType userType);

        [Delete("api/UserType/{id}")]
        RestResponse<Response<UserType>> deleteUserTypeById([Path("id")] int id);
    }
}
