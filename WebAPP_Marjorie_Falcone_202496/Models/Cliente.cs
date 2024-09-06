using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI__Marjorie_Falcone_202496.Models
{
   
    public class Cliente
    {
        public Cliente()
        {
            Prestamos = new HashSet<Prestamo>();
        }
      
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
