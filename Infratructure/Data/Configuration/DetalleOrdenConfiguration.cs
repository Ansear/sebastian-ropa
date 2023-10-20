using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {
        builder.ToTable("DetalleOrden");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.CantidadProducir);

        builder.Property(d => d.CantidadProducida);

        builder.HasOne(d => d.Colores).WithMany(d => d.DetalleOrdenes).HasForeignKey(d => d.IdColor);

        builder.HasOne(d => d.Ordenes).WithMany(d => d.DetalleOrdenes).HasForeignKey(d => d.IdOrden);

        builder.HasOne(d => d.Prendas).WithMany(d => d.DetalleOrdenes).HasForeignKey(d => d.IdPrenda);
         
        builder.HasOne(d => d.Estados).WithMany(d => d.DetalleOrdenes).HasForeignKey(d => d.IdEstado);
    }
}