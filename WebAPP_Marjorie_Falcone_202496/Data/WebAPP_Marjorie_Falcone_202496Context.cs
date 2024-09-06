using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI__Marjorie_Falcone_202496.Models;

namespace WebAPP_Marjorie_Falcone_202496.Data
{
    public class WebAPP_Marjorie_Falcone_202496Context : DbContext
    {
        public WebAPP_Marjorie_Falcone_202496Context (DbContextOptions<WebAPP_Marjorie_Falcone_202496Context> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; } = default!;

        public DbSet<Pago>? Pago { get; set; }

        public DbSet<Prestamo>? Prestamo { get; set; }
    }
}
