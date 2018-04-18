using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWalletApp.WebAPI.Models
{
    [Table("Ingresos")]
    public class Ingreso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Monto { get; set; }
        public string Descripcion { get; set; }
        public int FuenteId { get; set; }
        public DateTime Fecha { get; set; }

        // Navigation property
        public virtual Fuente Fuente { get; set; }
    }
}