using RestSharp;
using Retrofit.Net;
using SalamancaWeb.Resources;
using SalamancaWeb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalamancaWeb.Models
{
    public class LoginUser
    {
        [Display(Name = "Usuario:")]
        [Required]
        public int idLoginUser { get; set; }

        [Display(Name = "Persona:")]
        [Required]
        public int idPerson { get; set; }

        [Display(Name = "Tipo de Usuario:")]
        [Required]
        public int idUserType { get; set; }

        [Display(Name = "Usuario:")]
        [Required]
        [MaxLength(25)]
        public string username { get; set; }

        [Display(Name = "Clave:")]
        [Required]
        [MaxLength(255)]
        public string password { get; set; }

        [Display(Name = "Fecha Creacion:")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dateCreated { get; set; }

        public Person person { get; set; }

        public UserType userType { get; set; }

        //Implementacion de Metodos
        public Response<List<LoginUser>> getUsers()
        {
            var response = new Response<List<LoginUser>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_LoginUserService service = adapter.Create<I_LoginUserService>();
                RestResponse<Response<List<LoginUser>>> responseServer = service.getLoginUsers();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_USER, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<LoginUser> getUserById(int id)
        {
            var response = new Response<LoginUser>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_LoginUserService service = adapter.Create<I_LoginUserService>();
                RestResponse<Response<LoginUser>> responseServer = service.getLoginUserById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_USER, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<LoginUser> createUser()
        {
            var response = new Response<LoginUser>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_LoginUserService service = adapter.Create<I_LoginUserService>();
                RestResponse<Response<LoginUser>> responseServer = service.createLoginUser(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_USER, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<LoginUser> updateUser()
        {
            var response = new Response<LoginUser>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_LoginUserService service = adapter.Create<I_LoginUserService>();
                RestResponse<Response<LoginUser>> responseServer = service.updateLoginUser(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_USER, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<LoginUser> deleteUserById(int id)
        {
            var response = new Response<LoginUser>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_LoginUserService service = adapter.Create<I_LoginUserService>();
                RestResponse<Response<LoginUser>> responseServer = service.deleteLoginUserById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_USER, new List<string> { ex.ToString() });
            }
            return response;
        }
    }
}