using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI__Marjorie_Falcone_202496.Models
{
    public partial class Pago
    {
        
        public int IdPago { get; set; }
        public int? IdPrestamo { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal? Comisiones { get; set; }

        public virtual Prestamo? IdPrestamoNavigation { get; set; }
    }
}
