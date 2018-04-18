using MyWalletApp.WebAPI.BusinessLogic;
using MyWalletApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWalletApp.WebAPI.Controllers
{
    public class ServicioController : ApiController
    {
        private ServicioManager servicioManager;

        public ServicioController()
        {
            servicioManager = new ServicioManager();
        }

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var servicios = servicioManager.GetAllServicios();
            return Request.CreateResponse(HttpStatusCode.OK, servicios);
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var servicio = servicioManager.SearchById(id);
            return Request.CreateResponse(HttpStatusCode.OK, servicio);
        }

        // POST api/<controller>
        public void Post(Servicio servicio)
        {
            try
            {
                servicioManager.AddServicio(servicio);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, Servicio servicio)
        {
            try
            {
                servicioManager.UpdateServicio(id, servicio);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var servicio = servicioManager.SearchById(id);

            if (servicio == null)
                throw new Exception("Servicio no existe");

            servicioManager.DeleteServicio(servicio);
        }
    }
}