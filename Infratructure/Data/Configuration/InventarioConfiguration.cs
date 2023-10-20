using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("Inventario");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.HasIndex(d => d.CodInv).IsUnique();
        builder.Property(d => d.CodInv);

        builder.Property(d => d.ValorVtaCop);
        
        builder.Property(d => d.ValorVtaUsd);
        
        builder.HasOne(d => d.Prendas).WithMany(d => d.Inventarios).HasForeignKey(d => d.IdPrenda);
    }
}