using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {
        builder.ToTable("Orden");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Fecha).HasColumnType("date");

        builder.HasOne(d => d.Empleados).WithMany(d => d.Ordenes).HasForeignKey(d => d.IdEmpleado);
        
        builder.HasOne(d => d.Estados).WithMany(d => d.Ordenes).HasForeignKey(d => d.IdCliente);
        
        builder.HasOne(d => d.Clientes).WithMany(d => d.Ordenes).HasForeignKey(d => d.IdEstado);
    }
}