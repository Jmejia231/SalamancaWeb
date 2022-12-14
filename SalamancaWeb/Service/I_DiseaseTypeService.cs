using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_DiseaseTypeService {
        [Get("api/DiseaseType")]
        RestResponse<Response<List<DiseaseType>>> getDiseaseTypes();

        [Get("api/DiseaseType/{id}")]
        RestResponse<Response<DiseaseType>> getDiseaseTypeById([Path("id")] int id);

        [Post("api/DiseaseType")]
        RestResponse<Response<DiseaseType>> createDiseaseType([Body] DiseaseType diseaseType);

        [Put("api/DiseaseType")]
        RestResponse<Response<DiseaseType>> updateDiseaseType([Body] DiseaseType diseaseType);

        [Delete("api/DiseaseType/{id}")]
        RestResponse<Response<DiseaseType>> deleteDiseaseTypeById([Path("id")] int id);
    }
}
