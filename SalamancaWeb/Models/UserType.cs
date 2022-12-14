using RestSharp;
using Retrofit.Net;
using SalamancaWeb.Resources;
using SalamancaWeb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace SalamancaWeb.Models
{
    public class UserType
    {
        [Display(Name = "Tipo de Usuario:")]
        [Required]
        public int idUserType { get; set; }

        [Display(Name = "Nombre del Tipo de Usuario:")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Nivel de Acceso:")]
        [Required]
        public int accessLevel { get; set; }

        //Implementacion de Metodos
        public Response<List<UserType>> getUserTypes()
        {
            var response = new Response<List<UserType>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_UserTypeService service = adapter.Create<I_UserTypeService>();
                RestResponse<Response<List<UserType>>> responseServer = service.getUserTypes();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_USER_TYPE, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<UserType> getUserTypeById(int id)
        {
            var response = new Response<UserType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_UserTypeService service = adapter.Create<I_UserTypeService>();
                RestResponse<Response<UserType>> responseServer = service.getUserTypeById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_USER_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<UserType> createUserType()
        {
            var response = new Response<UserType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_UserTypeService service = adapter.Create<I_UserTypeService>();
                RestResponse<Response<UserType>> responseServer = service.createUserType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_USER_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<UserType> updateUserType()
        {
            var response = new Response<UserType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_UserTypeService service = adapter.Create<I_UserTypeService>();
                RestResponse<Response<UserType>> responseServer = service.updateUserType(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_USER_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<UserType> deleteUserTypeById(int id)
        {
            var response = new Response<UserType>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_UserTypeService service = adapter.Create<I_UserTypeService>();
                RestResponse<Response<UserType>> responseServer = service.deleteUserTypeById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_USER_TYPE, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeUserTypeItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione Tipo de Usuario",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var userTypes = getUserTypes().result.OrderByDescending(x => x.accessLevel).ToList();

            List<SelectListItem> userTypeItems = userTypes.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.name,
                    Value = x.idUserType.ToString(),
                    Selected = false,
                };
            });
            return userTypeItems;
        }
    }
}