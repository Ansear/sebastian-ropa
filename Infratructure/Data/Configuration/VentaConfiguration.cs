using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("Venta");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Fecha).HasColumnType("date");
        
        builder.HasOne(d => d.Empleados).WithMany(d => d.Ventas).HasForeignKey(d => d.IdEmpleado);

        builder.HasOne(d => d.Clientes).WithMany(d => d.Ventas).HasForeignKey(d => d.IdCliente);

        builder.HasOne(d => d.FormaPagos).WithMany(d => d.Ventas).HasForeignKey(d => d.IdFormaPago);
    }
}