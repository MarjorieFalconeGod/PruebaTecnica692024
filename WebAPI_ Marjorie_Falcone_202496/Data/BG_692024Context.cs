using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPI__Marjorie_Falcone_202496.Models;

namespace WebAPI__Marjorie_Falcone_202496.Data
{
    public partial class BG_692024Context : DbContext
    {
        public BG_692024Context()
        {
        }

        public BG_692024Context(DbContextOptions<BG_692024Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__D5946642E738B837");

                entity.HasIndex(e => e.CorreoElectronico, "UQ__Clientes__531402F39E2D2C92")
                    .IsUnique();

                entity.Property(e => e.Contraseña).HasMaxLength(100);

                entity.Property(e => e.CorreoElectronico).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pagos__FC851A3AFB7FA4DE");

                entity.Property(e => e.Capital).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Comisiones).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FechaPago).HasColumnType("date");

                entity.Property(e => e.Interes).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdPrestamoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdPrestamo)
                    .HasConstraintName("FK__Pagos__IdPrestam__3D5E1FD2");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PK__Prestamo__6FF194C0D6EB7AD4");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TasaInteres).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Prestamos__IdCli__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
