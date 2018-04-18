﻿using MyWalletApp.WebAPI.Data.Contexts;
using MyWalletApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWalletApp.WebAPI.Data.Repositories
{
    public class ServicioRepository
    {
        private MyWalletContext context;

        public ServicioRepository()
        {
            context = new MyWalletContext();
        }

        public IEnumerable<Servicio> GetAllServicios()
        {
            return context.Servicios.ToList();
        }

        public Servicio AddServicio(Servicio servicio)
        {
            context.Servicios.Add(servicio);
            context.SaveChanges();

            return servicio;
        }

        public Servicio SearchById(int id)
        {
            return context.Servicios.Find(id);
        }

        public Servicio UpdateServicio(Servicio servicio)
        {
            context.Entry(servicio).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return servicio;
        }

        public Servicio DeleteServicio(Servicio servicio)
        {
            context.Servicios.Remove(servicio);
            context.SaveChanges();

            return servicio;
        }

        public IEnumerable<Servicio> GetServiciosWithinNextFiveDays()
        {
            var today = DateTime.Now;
            var until = DateTime.Now.AddDays(5);
            List<Servicio> serviciosProximos = new List<Servicio>();

            serviciosProximos.AddRange(context.Servicios.Where(s => s.EsPorMes == false &&
                s.FechaPago >= today && s.FechaPago <= until).ToList());


            if (today.Month == until.Month)
            {
                serviciosProximos.AddRange(context.Servicios
                .Where(g => g.EsPorMes == true && g.FechaPago.Value.Day >= today.Day && g.FechaPago.Value.Day <= until.Day)
                .ToList());
            }
            else
            {
                serviciosProximos.AddRange(context.Servicios
                .Where(g => g.EsPorMes == true && g.FechaPago.Value.Day >= DateTime.Now.Day && g.FechaPago.Value.Day <= 31 ||
                       g.EsPorMes == true && g.FechaPago.Value.Day >= 1 && g.FechaPago.Value.Day <= until.Day)
                .ToList());
            }

            return serviciosProximos;
        }

        public IEnumerable<Servicio> GetNextMonthServiciosToPay()
        {
            var nextMonthDate = DateTime.Now.AddMonths(1);

            var serviciosAPagarProximoMes = context.Servicios.Where(s => s.EsPorMes == true).ToList();
            serviciosAPagarProximoMes.AddRange(context.Servicios.Where(s => s.EsPorMes == false &&
                s.FechaPago.Value.Month == nextMonthDate.Month).ToList());

            return serviciosAPagarProximoMes;
        }
    }
}