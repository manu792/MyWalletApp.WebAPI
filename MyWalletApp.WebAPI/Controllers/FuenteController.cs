using MyWalletApp.WebAPI.BusinessLogic;
using MyWalletApp.WebAPI.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWalletApp.WebAPI.Controllers
{
    public class FuenteController : ApiController
    {
        private FuenteManager fuenteManager;

        public FuenteController()
        {
            fuenteManager = new FuenteManager();
        }

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var fuentes = fuenteManager.GetAllFuentes().Where(f => !f.Nombre.ToLower().Equals("otro"));
            return Request.CreateResponse(HttpStatusCode.OK, fuentes);
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var fuente = fuenteManager.SearchById(id);
            return Request.CreateResponse(HttpStatusCode.OK, fuente);
        }

        // POST api/<controller>
        public void Post(Fuente fuente)
        {
            try
            {
                fuenteManager.AddFuente(fuente);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, Fuente fuente)
        {
            try
            {
                fuenteManager.UpdateFuente(id, fuente);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var fuente = fuenteManager.SearchById(id);

            if (fuente == null)
                throw new Exception("Fuente no existe");

            try
            {
                fuenteManager.DeleteFuente(fuente);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}