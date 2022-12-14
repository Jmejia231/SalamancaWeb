using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_DocumentIdentityTypeService {
        [Get("api/DocumentIdentityType")]
        RestResponse<Response<List<DocumentIdentityType>>> getDocumentIdentityTypes();

        [Get("api/DocumentIdentityType/{id}")]
        RestResponse<Response<DocumentIdentityType>> getDocumentIdentityTypeById([Path("id")] int id);

        [Post("api/DocumentIdentityType")]
        RestResponse<Response<DocumentIdentityType>> createDocumentIdentityType([Body] DocumentIdentityType documentIdentityType);

        [Put("api/DocumentIdentityType")]
        RestResponse<Response<DocumentIdentityType>> updateDocumentIdentityType([Body] DocumentIdentityType documentIdentityType);

        [Delete("api/DocumentIdentityType/{id}")]
        RestResponse<Response<DocumentIdentityType>> deleteDocumentIdentityTypeById([Path("id")] int id);
    }
}
