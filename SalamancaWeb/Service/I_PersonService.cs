using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_PersonService {
        [Get("api/Person")]
        RestResponse<Response<List<Person>>> getPersons();

        [Get("api/Person/{id}")]
        RestResponse<Response<Person>> getPersonById([Path("id")] int id);

        [Post("api/Person")]
        RestResponse<Response<Person>> createPerson([Body] Person person);

        [Put("api/Person")]
        RestResponse<Response<Person>> updatePerson([Body] Person person);

        [Delete("api/Person/{id}")]
        RestResponse<Response<Person>> deletePersonById([Path("id")] int id);
    }
}
