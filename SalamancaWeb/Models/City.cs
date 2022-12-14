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
    public class City
    {
        [Display(Name = "Departamento:")]
        [Required]
        public int idCity { get; set; }

        [Display(Name = "Pais:")]
        [Required]
        public int idCountry { get; set; }

        [Display(Name = "Nombre:")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        public Country country { get; set; }

        //Implementacion de Metodos
        public Response<List<City>> getCities()
        {
            var response = new Response<List<City>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CityService service = adapter.Create<I_CityService>();
                RestResponse<Response<List<City>>> responseServer = service.getCities();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_CITY, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<City> getCityById(int id)
        {
            var response = new Response<City>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CityService service = adapter.Create<I_CityService>();
                RestResponse<Response<City>> responseServer = service.getCityById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<City> createCity()
        {
            var response = new Response<City>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CityService service = adapter.Create<I_CityService>();
                RestResponse<Response<City>> responseServer = service.createCity(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<City> updateCity()
        {
            var response = new Response<City>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CityService service = adapter.Create<I_CityService>();
                RestResponse<Response<City>> responseServer = service.updateCity(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_COUNTRY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<City> deleteCityById(int id)
        {
            var response = new Response<City>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_CityService service = adapter.Create<I_CityService>();
                RestResponse<Response<City>> responseServer = service.deleteCityById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_CITY, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeCityItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione el Departamento",
                Value = "",
                Selected = true,
                Disabled = true
            };

            //var cities = getCities().result.Where(x => x.status).OrderBy(x => x.country.name).ThenBy(x => x.name).ToList();
            var cities = getCities().result.OrderBy(x => x.country.name).ThenBy(x => x.name).ToList();

            List<SelectListGroup> groups = cities.Select(x => new
            {
                idCountry = x.idCountry,
                country = x.country.name,
                status = x.country.status
            }).Distinct().ToList().ConvertAll(x =>
            {
                return new SelectListGroup()
                {
                    Name = x.country,
                    Disabled = !x.status
                };
            });

            List<SelectListItem> cityItems = cities.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.name : x.name + " (Inactivo)",
                    Value = x.idCity.ToString(),
                    Disabled = !x.status,
                    Group = groups.Find(y => y.Name.Equals(x.country.name)),
                    Selected = false,
                };
            });
            //countryItems.Insert(0, predetermine);
            return cityItems;
        }
    }
}