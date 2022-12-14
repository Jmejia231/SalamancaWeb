using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_CityService {
        [Get("api/City")]
        RestResponse<Response<List<City>>> getCities();

        [Get("api/City/{id}")]
        RestResponse<Response<City>> getCityById([Path("id")] int id);

        [Post("api/City")]
        RestResponse<Response<City>> createCity([Body] City city);

        [Put("api/City")]
        RestResponse<Response<City>> updateCity([Body] City city);

        [Delete("api/City/{id}")]
        RestResponse<Response<City>> deleteCityById([Path("id")] int id);
    }
}
