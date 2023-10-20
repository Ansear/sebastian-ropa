using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class InsumoProveedorConfiguration : IEntityTypeConfiguration<InsumoProveedor>
{
    public void Configure(EntityTypeBuilder<InsumoProveedor> builder)
    {
        builder.ToTable("InsumoProveedor");

        builder.HasKey(d => new { d.IdInsumo, d.IdProveedor });

        builder.HasOne(d => d.Insumos).WithMany(d => d.InsumoProveedores).HasForeignKey(d => d.IdInsumo);
        
        builder.HasOne(d => d.Proveedores).WithMany(d => d.InsumoProveedores).HasForeignKey(d => d.IdProveedor);
    }
}