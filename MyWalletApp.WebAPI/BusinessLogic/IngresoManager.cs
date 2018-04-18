using MyWalletApp.WebAPI.Data.Repositories;
using MyWalletApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWalletApp.WebAPI.BusinessLogic
{
    public class IngresoManager
    {
        private IngresoRepository repository;

        public IngresoManager()
        {
            repository = new IngresoRepository();
        }

        public IEnumerable<Ingreso> GetAllIngresos()
        {
            var ingresos = repository.GetAllIngresos();

            return ingresos.Select(i => new Ingreso()
            {
                Id = i.Id,
                Monto = i.Monto,
                Descripcion = i.Descripcion,
                Fuente = new Fuente()
                {
                    Id = i.Fuente.Id,
                    Nombre = i.Fuente.Nombre
                },
                Fecha = i.Fecha
            }).ToList();
        }

        public IEnumerable<Ingreso> GetIngresosByDateRange(DateTime? start = null, DateTime? end = null)
        {
            if (start == null || end == null)
            {
                start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                end = DateTime.Now;
            }
            var ingresos = repository.GetIngresosByDateRange(Convert.ToDateTime(start), Convert.ToDateTime(end));

            return ingresos.Select(i => new Ingreso()
            {
                Id = i.Id,
                Monto = i.Monto,
                Descripcion = i.Descripcion,
                Fuente = new Fuente()
                {
                    Id = i.Fuente.Id,
                    Nombre = i.Fuente.Nombre
                },
                Fecha = i.Fecha
            }).ToList();
        }

        public Ingreso AddIngreso(Ingreso ingreso)
        {
            repository.AddIngreso(new Ingreso()
            {
                Monto = ingreso.Monto,
                Descripcion = ingreso.Descripcion,
                FuenteId = ingreso.Fuente.Id,
                Fecha = ingreso.Fecha
            });

            return ingreso;
        }

        public Ingreso SearchById(int id)
        {
            var ingreso = repository.SearchById(id);

            if (ingreso == null)
                return null;

            return new Ingreso()
            {
                Id = ingreso.Id,
                Monto = ingreso.Monto,
                Descripcion = ingreso.Descripcion,
                Fuente = new Fuente()
                {
                    Id = ingreso.Fuente.Id,
                    Nombre = ingreso.Fuente.Nombre
                },
                Fecha = ingreso.Fecha
            };
        }

        public Ingreso UpdateIngreso(int id, Ingreso ingreso)
        {
            repository.UpdateIngreso(new Ingreso()
            {
                Id = ingreso.Id,
                Fecha = ingreso.Fecha,
                FuenteId = ingreso.Fuente.Id,
                Monto = ingreso.Monto,
                Descripcion = ingreso.Descripcion
            });

            return ingreso;
        }

        public Ingreso DeleteIngreso(Ingreso ingreso)
        {
            var deletedIngreso = repository.SearchById(ingreso.Id);

            repository.DeleteIngreso(deletedIngreso);

            return ingreso;
        }
    }
}