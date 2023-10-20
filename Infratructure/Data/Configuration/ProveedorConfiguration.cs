using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedor");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.HasIndex(d => d.NitProveedor).IsUnique();
        builder.Property(d => d.NitProveedor);

        builder.Property(d => d.Nombre);

        builder.HasOne(d => d.TipoPersonas).WithMany(d => d.Proveedores).HasForeignKey(d => d.IdTipoPersona);
        
        builder.HasOne(d => d.Municipios).WithMany(d => d.Proveedores).HasForeignKey(d => d.IdMunicipio);
    }
}