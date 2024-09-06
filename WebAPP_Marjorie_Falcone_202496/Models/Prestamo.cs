using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI__Marjorie_Falcone_202496.Models
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            Pagos = new HashSet<Pago>();
        }
        
        public int IdPrestamo { get; set; }
        public decimal Monto { get; set; }
        public int Plazo { get; set; }
        public decimal TasaInteres { get; set; }
        public string Estado { get; set; } = null!;
        public int? IdCliente { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
