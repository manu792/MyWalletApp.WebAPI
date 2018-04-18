﻿using MyWalletApp.WebAPI.Data.Contexts;
using MyWalletApp.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWalletApp.WebAPI.Repositories
{
    public class FuenteRepository
    {
        private MyWalletContext context;

        public FuenteRepository()
        {
            context = new MyWalletContext();
        }

        public IEnumerable<Fuente> GetAllFuentes()
        {
            return context.Fuentes.ToList();
        }

        public Fuente AddFuente(Fuente fuente)
        {
            context.Fuentes.Add(fuente);
            context.SaveChanges();

            return fuente;
        }

        public Fuente SearchById(int id)
        {
            return context.Fuentes.Find(id);
        }

        public Fuente UpdateFuente(Fuente fuente)
        {
            context.Entry(fuente).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return fuente;
        }

        public Fuente DeleteFuente(Fuente fuente)
        {
            context.Fuentes.Remove(fuente);
            context.SaveChanges();

            return fuente;
        }
    }
}