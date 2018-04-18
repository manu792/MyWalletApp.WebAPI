using MyWalletApp.WebAPI.Data.Contexts;
using MyWalletApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyWalletApp.WebAPI.Data.Repositories
{
    public class GastoRepository
    {
        private MyWalletContext context;

        public GastoRepository()
        {
            context = new MyWalletContext();
        }

        public IEnumerable<Gasto> GetAllGastos()
        {
            return context.Gastos.ToList();
        }

        public Gasto SearchById(int id)
        {
            return context.Gastos.Find(id);
        }

        public Gasto AddGasto(Gasto gasto)
        {
            context.Gastos.Add(gasto);
            context.SaveChanges();

            return gasto;
        }

        public Gasto UpdateGasto(Gasto gasto)
        {
            context.Entry(gasto).State = EntityState.Modified;
            context.SaveChanges();

            return gasto;
        }

        public Gasto DeleteGasto(Gasto gasto)
        {
            context.Gastos.Remove(gasto);
            context.SaveChanges();

            return gasto;
        }

        public IEnumerable<Gasto> GetGastosByDateRange(DateTime start, DateTime end)
        {
            return context.Gastos.Where(g => g.Fecha >= start && g.Fecha <= end);
        }
    }
}