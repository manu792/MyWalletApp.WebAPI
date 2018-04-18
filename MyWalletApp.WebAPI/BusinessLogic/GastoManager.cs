using MyWalletApp.WebAPI.Data.Repositories;
using MyWalletApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyWalletApp.WebAPI.BusinessLogic
{
    public class GastoManager
    {
        private GastoRepository repository;

        public GastoManager()
        {
            repository = new GastoRepository();
        }

        public IEnumerable<Gasto> GetAllGastos()
        {
            var ingresos = repository.GetAllGastos();

            return ingresos.Select(i => new Gasto()
            {
                Id = i.Id,
                Monto = i.Monto,
                Descripcion = i.Descripcion,
                Servicio = new Servicio()
                {
                    Id = i.Servicio.Id,
                    Nombre = i.Servicio.Nombre
                },
                Fecha = i.Fecha
            }).ToList();
        }

        public IEnumerable<Gasto> GetGastosByDateRange(DateTime? start = null, DateTime? end = null)
        {
            if (start == null || end == null)
            {
                start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                end = DateTime.Now;
            }
            var ingresos = repository.GetGastosByDateRange(Convert.ToDateTime(start), Convert.ToDateTime(end));

            return ingresos.Select(i => new Gasto()
            {
                Id = i.Id,
                Monto = i.Monto,
                Descripcion = i.Descripcion,
                Servicio = new Servicio()
                {
                    Id = i.Servicio.Id,
                    Nombre = i.Servicio.Nombre
                },
                Fecha = i.Fecha
            }).ToList();
        }

        public Gasto SearchById(int id)
        {
            var gasto = repository.SearchById(id);

            if (gasto == null)
                return null;

            return new Gasto()
            {
                Id = gasto.Id,
                Monto = gasto.Monto,
                Descripcion = gasto.Descripcion,
                Servicio = new Servicio()
                {
                    Id = gasto.Servicio.Id,
                    Nombre = gasto.Servicio.Nombre
                },
                Fecha = gasto.Fecha
            };
        }

        public Gasto AddGasto(Gasto gasto)
        {
            repository.AddGasto(new Gasto()
            {
                Monto = gasto.Monto,
                Descripcion = gasto.Descripcion,
                ServicioId = gasto.Servicio.Id,
                Fecha = gasto.Fecha
            });

            return gasto;
        }

        public Gasto UpdateGasto(Gasto gasto)
        {
            repository.UpdateGasto(new Gasto()
            {
                Id = gasto.Id,
                Monto = gasto.Monto,
                Descripcion = gasto.Descripcion,
                ServicioId = gasto.Servicio.Id,
                Fecha = gasto.Fecha
            });

            return gasto;
        }

        public Gasto DeleteGasto(Gasto gasto)
        {
            var deletedGasto = repository.SearchById(gasto.Id);
            repository.DeleteGasto(deletedGasto);

            return gasto;
        }
    }
}