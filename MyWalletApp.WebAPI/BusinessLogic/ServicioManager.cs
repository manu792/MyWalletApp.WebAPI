using MyWalletApp.WebAPI.Data.Repositories;
using MyWalletApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWalletApp.WebAPI.BusinessLogic
{
    public class ServicioManager
    {
        private ServicioRepository repository;

        public ServicioManager()
        {
            repository = new ServicioRepository();
        }

        public IEnumerable<Servicio> GetAllServicios()
        {
            var servicios = repository.GetAllServicios().OrderBy(s => s.Nombre.ToLower().Equals("otro")).ThenBy(s => s.Id);

            return servicios.Select(s => new Servicio()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Monto = s.Monto,
                FechaPago = s.FechaPago,
                EsPorMes = Convert.ToBoolean(s.EsPorMes)
            }).ToList();
        }

        public Servicio AddServicio(Servicio servicio)
        {
            repository.AddServicio(new Servicio()
            {
                Nombre = servicio.Nombre,
                Monto = servicio.Monto,
                FechaPago = servicio.FechaPago,
                EsPorMes = servicio.EsPorMes
            });

            return servicio;
        }

        public Servicio SearchById(int id)
        {
            var servicio = repository.SearchById(id);

            if (servicio == null)
                return null;

            return new Servicio()
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Monto = servicio.Monto,
                FechaPago = servicio.FechaPago,
                EsPorMes = Convert.ToBoolean(servicio.EsPorMes)
            };
        }

        public Servicio UpdateServicio(int id, Servicio servicio)
        {
            repository.UpdateServicio(new Servicio()
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Monto = servicio.Monto,
                FechaPago = servicio.FechaPago,
                EsPorMes = servicio.EsPorMes
            });

            return servicio;
        }

        public Servicio DeleteServicio(Servicio servicio)
        {
            var deleteServicio = repository.SearchById(servicio.Id);
            repository.DeleteServicio(deleteServicio);

            return servicio;
        }

        public IEnumerable<Servicio> GetServiciosWithinNextFiveDays()
        {
            var servicios = repository.GetServiciosWithinNextFiveDays();

            return servicios.Select(s => new Servicio()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Monto = s.Monto,
                FechaPago = s.FechaPago,
                EsPorMes = Convert.ToBoolean(s.EsPorMes)
            }).ToList();
        }

        public IEnumerable<Servicio> GetNextMonthServiciosToPay()
        {
            var servicios = repository.GetNextMonthServiciosToPay();

            return servicios.Select(s => new Servicio()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Monto = s.Monto,
                FechaPago = s.FechaPago,
                EsPorMes = Convert.ToBoolean(s.EsPorMes)
            }).ToList();
        }
    }
}