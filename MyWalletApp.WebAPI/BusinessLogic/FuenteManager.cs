using MyWalletApp.WebAPI.Models;
using MyWalletApp.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWalletApp.WebAPI.BusinessLogic
{
    public class FuenteManager
    {
        private FuenteRepository repository;

        public FuenteManager()
        {
            repository = new FuenteRepository();
        }

        public IEnumerable<Fuente> GetAllFuentes()
        {
            var fuentes = repository.GetAllFuentes().OrderBy(f => f.Nombre.ToLower().Equals("otro")).ThenBy(f => f.Id);

            return fuentes.Select(i => new Fuente()
            {
                Id = i.Id,
                Nombre = i.Nombre
            }).ToList();
        }

        public Fuente AddFuente(Fuente fuente)
        {
            repository.AddFuente(new Fuente()
            {
                Nombre = fuente.Nombre
            });

            return fuente;
        }

        public Fuente SearchById(int id)
        {
            var servicio = repository.SearchById(id);

            if (servicio == null)
                return null;

            return new Fuente()
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre
            };
        }

        public Fuente UpdateFuente(int id, Fuente fuente)
        {
            repository.UpdateFuente(new Fuente()
            {
                Id = fuente.Id,
                Nombre = fuente.Nombre,
            });

            return fuente;
        }

        public Fuente DeleteFuente(Fuente fuente)
        {
            var deleteFuente = repository.SearchById(fuente.Id);
            repository.DeleteFuente(deleteFuente);

            return fuente;
        }
    }
}