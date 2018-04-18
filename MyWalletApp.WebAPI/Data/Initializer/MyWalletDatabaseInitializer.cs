﻿using MyWalletApp.WebAPI.Data.Contexts;
using MyWalletApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyWalletApp.WebAPI.Data.Initializer
{
    public class MyWalletDatabaseInitializer : DropCreateDatabaseIfModelChanges<MyWalletContext>
    {
        private MyWalletContext dbContext;
        protected override void Seed(MyWalletContext context)
        {
            dbContext = context;

            SeedServicios();
            SeedFuentes();
            base.Seed(context);
        }

        private void SeedFuentes()
        {
            dbContext.Fuentes.AddRange(new List<Fuente>()
            {
                new Fuente()
                {
                    Id = 1,
                    Nombre = "Salario"
                },
                new Fuente()
                {
                    Id = 2,
                    Nombre = "Transaccion"
                },
                new Fuente()
                {
                    Id = 3,
                    Nombre = "Otro"
                }
            });
            dbContext.SaveChanges();
        }

        private void SeedServicios()
        {
            dbContext.Servicios.AddRange(new List<Servicio>()
                    {
                        new Servicio
                        {
                            Id = 1,
                            Nombre = "Netflix",
                            Monto = 4500,
                            FechaPago = Convert.ToDateTime("2018-02-24"),
                            EsPorMes = true
                        },
                        new Servicio
                        {
                            Id = 2,
                            Nombre = "HBO GO",
                            Monto = 4900,
                            FechaPago = Convert.ToDateTime("2018-02-20"),
                            EsPorMes = true
                        },
                        new Servicio
                        {
                            Id = 3,
                            Nombre = "Agua",
                            Monto = 9800,
                            FechaPago = Convert.ToDateTime("2018-02-15"),
                            EsPorMes = true
                        },
                        new Servicio
                        {
                            Id = 4,
                            Nombre = "Luz",
                            Monto = 26300,
                            FechaPago = Convert.ToDateTime("2018-02-02"),
                            EsPorMes = true
                        },
                        new Servicio
                        {
                            Id = 5,
                            Nombre = "Celular",
                            Monto = 28000,
                            FechaPago = Convert.ToDateTime("2018-02-15"),
                            EsPorMes = true
                        },
                        new Servicio
                        {
                            Id = 6,
                            Nombre = "Cable",
                            Monto = 35000,
                            FechaPago = Convert.ToDateTime("2018-02-23"),
                            EsPorMes = true
                        },
                        new Servicio
                        {
                            Id = 7,
                            Nombre = "Prestamo carro",
                            Monto = 250000,
                            FechaPago = Convert.ToDateTime("2018-02-15"),
                            EsPorMes = false
                        },
                        new Servicio
                        {
                            Id = 8,
                            Nombre = "Otro",
                            Monto = 0
                        }
                    });
            dbContext.SaveChanges();
        }
    }
}