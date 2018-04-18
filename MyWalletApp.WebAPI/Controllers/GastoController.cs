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
    public class GastoController : ApiController
    {
        private GastoManager gastoManager;

        public GastoController()
        {
            gastoManager = new GastoManager();
        }

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var gastos = gastoManager.GetAllGastos();
            return Request.CreateResponse(HttpStatusCode.OK, gastos);
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var gasto = gastoManager.SearchById(id);
            return Request.CreateResponse(HttpStatusCode.OK, gasto);
        }

        // POST api/<controller>
        public void Post(Gasto gasto)
        {
            try
            {
                gastoManager.AddGasto(gasto);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, Gasto gasto)
        {
            try
            {
                gastoManager.UpdateGasto(gasto);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var gasto = gastoManager.SearchById(id);

            if (gasto == null)
                throw new Exception("Gasto no existe");

            gastoManager.DeleteGasto(gasto);
        }
    }
}