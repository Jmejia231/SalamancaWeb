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
    public class Person
    {
        [Display(Name = "Persona:")]
        [Required]
        public int idPerson { get; set; }

        [Display(Name = "Tipo de Documento Indentidad:")]
        [Required]
        public int idDocumentIdentityType { get; set; }

        [Display(Name = "Departamento:")]
        [Required]
        public int idCity { get; set; }

        [Display(Name = "Genero:")]
        [Required]
        public int idGender { get; set; }

        [Display(Name = "Nombres:")]
        [Required]
        [MaxLength(100)]
        public string names { get; set; }

        [Display(Name = "Apellido Paterno:")]
        [Required]
        [MaxLength(50)]
        public string fatherLastname { get; set; }

        [Display(Name = "Apellido Materno:")]
        [Required]
        [MaxLength(50)]
        public string motherLastname { get; set; }

        [Display(Name = "Fecha Nacimiento:")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime birthdate { get; set; }

        [Display(Name = "Numero de Documento Identidad:")]
        [Required]
        [MaxLength(20)]
        public string documentIdentityNumber { get; set; }

        [Display(Name = "Direccion:")]
        [Required]
        [MaxLength(100)]
        public string address { get; set; }

        [Display(Name = "Telefono:")]
        [Required]
        [MaxLength(12)]
        public string phoneNumber { get; set; }

        [Display(Name = "Correo:")]
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Es Paciente?")]
        [Required]
        public bool isPatient { get; set; }

        [Display(Name = "Estado:")]
        [Required]
        public bool status { get; set; }

        public DocumentIdentityType documentIdentityType { get; set; }

        public City city { get; set; }

        public Gender gender { get; set; }

        //Implementacion de Metodos
        public Response<List<Person>> getPersons()
        {
            var response = new Response<List<Person>>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_PersonService service = adapter.Create<I_PersonService>();
                RestResponse<Response<List<Person>>> responseServer = service.getPersons();
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_GET_PERSON, new List<string> { ex.Message.ToString() });
            }
            return response;
        }

        public Response<Person> getPersonById(int id)
        {
            var response = new Response<Person>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_PersonService service = adapter.Create<I_PersonService>();
                RestResponse<Response<Person>> responseServer = service.getPersonById(id);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_SEARCH_PERSON, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Person> createPerson()
        {
            var response = new Response<Person>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_PersonService service = adapter.Create<I_PersonService>();
                RestResponse<Response<Person>> responseServer = service.createPerson(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_ADD_PERSON, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Person> updatePerson()
        {
            var response = new Response<Person>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_PersonService service = adapter.Create<I_PersonService>();
                RestResponse<Response<Person>> responseServer = service.updatePerson(this);
                response = responseServer.Data != null ? responseServer.Data.result != null ? responseServer.Data : response.createNoDataResponse() : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_UPDATE_PERSON, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Person> deletePersonById(int id)
        {
            var response = new Response<Person>();
            try
            {
                RestAdapter adapter = new RestAdapter(Resource.BaseUrlApi);
                I_PersonService service = adapter.Create<I_PersonService>();
                RestResponse<Response<Person>> responseServer = service.deletePersonById(id);
                response = responseServer.Data != null ? responseServer.Data : response.createNoDataResponse();
            }
            catch(Exception ex)
            {
                response = response.createErrorResponse(ErrorMessage.ERROR_DELETE_PERSON, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> initializeAllPersonItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione Persona",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var persons = getPersons().result.OrderBy(x => x.fatherLastname).ThenBy(x => x.motherLastname).ThenBy(x => x.names).ToList();

            List<SelectListItem> personItems = persons.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.fatherLastname + " " + x.motherLastname + ", " + x.names : x.fatherLastname + " " + x.motherLastname + ", " + x.names + " (Inactivo)",
                    Value = x.idPerson.ToString(),
                    Disabled = !x.status,
                    Selected = false,
                };
            });
            //countryItems.Insert(0, predetermine);
            return personItems;
        }

        public List<SelectListItem> initializeNoPatientsPersonItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione Persona",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var persons = getPersons().result.Where(x => !x.isPatient).OrderBy(x => x.fatherLastname).ThenBy(x => x.motherLastname).ThenBy(x => x.names).ToList();

            List<SelectListItem> personItems = persons.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.fatherLastname + " " + x.motherLastname + ", " + x.names : x.fatherLastname + " " + x.motherLastname + ", " + x.names + " (Inactivo)",
                    Value = x.idPerson.ToString(),
                    Disabled = !x.status,
                    Selected = false,
                };
            });
            //countryItems.Insert(0, predetermine);
            return personItems;
        }

        public List<SelectListItem> initializePatientsPersonItems()
        {
            var predetermine = new SelectListItem()
            {
                Text = "Seleccione Persona",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var persons = getPersons().result.Where(x => x.isPatient).OrderBy(x => x.fatherLastname).ThenBy(x => x.motherLastname).ThenBy(x => x.names).ToList();

            List<SelectListItem> personItems = persons.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.status ? x.fatherLastname + " " + x.motherLastname + ", " + x.names : x.fatherLastname + " " + x.motherLastname + ", " + x.names + " (Inactivo)",
                    Value = x.idPerson.ToString(),
                    Disabled = !x.status,
                    Selected = false,
                };
            });
            //countryItems.Insert(0, predetermine);
            return personItems;
        }

    }
}