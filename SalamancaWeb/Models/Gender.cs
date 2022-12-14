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
    public class Gender
    {
        [Display(Name = "Genero:")]
        [Required]
        public int idGender { get; set; }

        [Display(Name = "Nombre del Genero:")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        //Implementacion de Metodos
        public Response<List<Gender>> getGenders()
        {
            var response = new Response<List<Gender>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_GenderService service = adapter.Create<I_GenderService>();
                RestResponse<Response<List<Gender>>> responseServer = service.getGenders();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_GENDER, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<Gender> getGenderById(int id)
        {
            var response = new Response<Gender>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_GenderService service = adapter.Create<I_GenderService>();
                RestResponse<Response<Gender>> responseServer = service.getGenderById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_GENDER, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Gender> createGender()
        {
            var response = new Response<Gender>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_GenderService service = adapter.Create<I_GenderService>();
                RestResponse<Response<Gender>> responseServer = service.createGender(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_GENDER, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Gender> updateGender()
        {
            var response = new Response<Gender>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_GenderService service = adapter.Create<I_GenderService>();
                RestResponse<Response<Gender>> responseServer = service.updateGender(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_GENDER, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Gender> deleteGenderById(int id)
        {
            var response = new Response<Gender>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_GenderService service = adapter.Create<I_GenderService>();
                RestResponse<Response<Gender>> responseServer = service.deleteGenderById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_GENDER, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeGenderItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione Genero",
                Value = "",
                Selected = true,
                Disabled = true
            };

            //var genders = getGenders().result.Where(x => x.status).OrderBy(x => x.name).ToList();
            var genders = getGenders().result.OrderBy(x => x.name).ToList();

            List<SelectListItem> genderItems = genders.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.name : x.name + " (Inactivo)",
                    Value = x.idGender.ToString(),
                    Disabled = !x.status,
                    Selected = false,
                };
            });
            //countryItems.Insert(0, predetermine);
            return genderItems;
        }
    }
}