using SalamancaWeb.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalamancaWeb.Models
{
    public class Response<T_Entity> where T_Entity : new()
    {
        public bool success { get; set; }

        public T_Entity result { get; set; }

        public string displayMessage { get; set; }

        public List<string> errorMessage { get; set; }

        public string code { get; set; }

        
        public Response<T_Entity> createErrorResponse(string displayMessage, List<string> errorMessage)
        {
            this.success = false;
            this.result = new T_Entity();
            this.displayMessage = displayMessage;
            this.errorMessage = errorMessage;
            this.code = "400";
            return this;
        }

        public Response<T_Entity> createNoDataResponse() {
            success = false;
            result = new T_Entity();
            displayMessage = ErrorMessage.NoServer;
            errorMessage = new List<string>();
            return this;
        }
    }
}