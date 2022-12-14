using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_LoginUserService {
        [Get("api/LoginUser")]
        RestResponse<Response<List<LoginUser>>> getLoginUsers();

        [Get("api/LoginUser/{id}")]
        RestResponse<Response<LoginUser>> getLoginUserById([Path("id")] int id);

        [Post("api/LoginUser")]
        RestResponse<Response<LoginUser>> createLoginUser([Body] LoginUser loginUser);

        [Put("api/LoginUser")]
        RestResponse<Response<LoginUser>> updateLoginUser([Body] LoginUser loginUser);

        [Delete("api/LoginUser/{id}")]
        RestResponse<Response<LoginUser>> deleteLoginUserById([Path("id")] int id);
    }
}
