using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.ToTable("Insumo");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.HasIndex(d => d.Nombre).IsUnique();
        builder.Property(d => d.Nombre).HasMaxLength(50);

        builder.Property(d => d.ValorUnit).HasColumnType("double");

        builder.Property(d => d.StockMin);

        builder.Property(d => d.StockMax);

    }
}