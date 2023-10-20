using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;

public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {
        builder.ToTable("Prenda");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.HasIndex(d => d.IdPrenda).IsUnique();
        builder.Property(d => d.IdPrenda);
        
        builder.Property(d => d.Nombre);

        builder.Property(d => d.ValorUnitCop).HasColumnType("double");
        
        builder.Property(d => d.ValorUnitUsd).HasColumnType("double");

        builder.HasOne(d => d.TipoProtecciones).WithMany(d => d.Prendas).HasForeignKey(d => d.IdTipoProteccion);

        builder.HasOne(d => d.Generos).WithMany(d => d.Prendas).HasForeignKey(d => d.IdGenero);
        
        builder.HasOne(d => d.Estados).WithMany(d => d.Prendas).HasForeignKey(d => d.IdEstado);
    }
}