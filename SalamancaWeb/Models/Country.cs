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
    public class Country
    {
        [Display(Name = "Pais:")]
        [Required]
        public int idCountry { get; set; }

        [Display(Name = "Nombre del Pais:")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        //Implementacion de Metodos
        public Response<List<Country>> getCountries()
        {
            var response = new Response<List<Country>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CountryService service = adapter.Create<I_CountryService>();
                RestResponse<Response<List<Country>>> responseServer = service.getCountries();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_COUNTRY, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<Country> getCountryById(int id)
        {
            var response = new Response<Country>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CountryService service = adapter.Create<I_CountryService>();
                RestResponse<Response<Country>> responseServer = service.getCountryById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Country> createCountry()
        {
            var response = new Response<Country>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CountryService service = adapter.Create<I_CountryService>();
                RestResponse<Response<Country>> responseServer = service.createCountry(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Country> updateCountry()
        {
            var response = new Response<Country>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CountryService service = adapter.Create<I_CountryService>();
                RestResponse<Response<Country>> responseServer = service.updateCountry(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Country> deleteCountryById(int id)
        {
            var response = new Response<Country>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CountryService service = adapter.Create<I_CountryService>();
                RestResponse<Response<Country>> responseServer = service.deleteCountryById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeCountryItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione Pais",
                Value = "",
                Selected = true,
                Disabled = true
            };

            //var countries = getCountries().result.Where(x => x.status).OrderBy(x => x.name).ToList();
            var countries = getCountries().result.OrderBy(x => x.name).ToList();

            List<SelectListItem> countryItems = countries.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.name : x.name + " (Inactivo)",
                    Value = x.idCountry.ToString(),
                    Disabled = !x.status,
                    Selected = false,
                };
            });
            //countryItems.Insert(0, predetermine);
            return countryItems;
        }
    }
}