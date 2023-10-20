using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
{
    public void Configure(EntityTypeBuilder<InventarioTalla> builder)
    {
        builder.ToTable("InventarioTalla");

        builder.HasKey(d => new { d.IdInv, d.IdTalla });

        builder.Property(d => d.Cantidad);

        builder.HasOne(d => d.Inventarios).WithMany(d => d.InventarioTallas).HasForeignKey(d => d.IdInv);
        
        builder.HasOne(d => d.Tallas).WithMany(d => d.InventarioTallas).HasForeignKey(d => d.IdTalla);
    }
}