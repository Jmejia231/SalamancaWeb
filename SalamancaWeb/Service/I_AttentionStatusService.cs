using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using SalamancaWeb.Models;
using System.Collections.Generic;

namespace SalamancaWeb.Service {
    public interface I_AttentionStatusService {
        [Get("api/AttentionStatus")]
        RestResponse<Response<List<AttentionStatus>>> getAttentionStatuses();

        [Get("api/AttentionStatus/{id}")]
        RestResponse<Response<AttentionStatus>> getAttentionStatusById([Path("id")] int id);

        [Post("api/AttentionStatus")]
        RestResponse<Response<AttentionStatus>> createAttentionStatus([Body] AttentionStatus attentionStatus);

        [Put("api/AttentionStatus")]
        RestResponse<Response<AttentionStatus>> updateAttentionStatus([Body] AttentionStatus attentionStatus);

        [Delete("api/AttentionStatus/{id}")]
        RestResponse<Response<AttentionStatus>> deleteAttentionStatusById([Path("id")] int id);
    }
}
