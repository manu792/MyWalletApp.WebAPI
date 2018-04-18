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
    public class IngresoController : ApiController
    {
        private IngresoManager ingresoManager;

        public IngresoController()
        {
            ingresoManager = new IngresoManager();
        }

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var ingresos = ingresoManager.GetAllIngresos();
            return Request.CreateResponse(HttpStatusCode.OK, ingresos);
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var ingreso = ingresoManager.SearchById(id);
            return Request.CreateResponse(HttpStatusCode.OK, ingreso);
        }

        // POST api/<controller>
        public void Post(Ingreso ingreso)
        {
            try
            {
                ingresoManager.AddIngreso(ingreso);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, Ingreso ingreso)
        {
            try
            {
                ingresoManager.UpdateIngreso(id, ingreso);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var ingreso = ingresoManager.SearchById(id);

            if (ingreso == null)
                throw new Exception("Ingreso no existe");

            ingresoManager.DeleteIngreso(ingreso);
        }
    }
}