using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration
{
    public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
    {
        public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
        {
            builder.ToTable("InsumoPrenda");

            builder.HasKey(d => new { d.IdInsumo, d.IdPrenda});

            builder.HasOne(d => d.Insumos).WithMany(d => d.InsumoPrendas).HasForeignKey(d => d.IdInsumo);
            
            builder.HasOne(d => d.Prendas).WithMany(d => d.InsumoPrendas).HasForeignKey(d => d.IdPrenda);
        }
    }
}