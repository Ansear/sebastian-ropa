using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id);

            builder.Property(d => d.Cantidad);

            builder.Property(d => d.ValorUnit);
            
            builder.HasOne(d => d.Ventas).WithMany(d => d.DetalleVentas).HasForeignKey(d => d.IdVenta);
            
            builder.HasOne(d => d.Inventarios).WithMany(d => d.DetalleVentas).HasForeignKey(d => d.IdProducto);
            
            builder.HasOne(d => d.Tallas).WithMany(d => d.DetalleVentas).HasForeignKey(d => d.IdTalla);
        }
    }
}