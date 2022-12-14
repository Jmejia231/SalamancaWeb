using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_CountryService {
        [Get("api/Country")]
        RestResponse<Response<List<Country>>> getCountries();

        [Get("api/Country/{id}")]
        RestResponse<Response<Country>> getCountryById([Path("id")] int id);

        [Post("api/Country")]
        RestResponse<Response<Country>> createCountry([Body] Country country);

        [Put("api/Country")]
        RestResponse<Response<Country>> updateCountry([Body] Country country);

        [Delete("api/Country/{id}")]
        RestResponse<Response<Country>> deleteCountryById([Path("id")] int id);
    }
}
