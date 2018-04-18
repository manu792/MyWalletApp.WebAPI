using System;

namespace MyWalletApp.WebAPI.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaPago { get; set; }
        public double Monto { get; set; }
        public bool? EsPorMes { get; set; }
    }
}