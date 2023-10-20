using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresa");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.HasIndex(d => d.Nit).IsUnique();
        builder.Property(d => d.Nit);

        builder.Property(d => d.RazonSocial);

        builder.Property(d => d.RepresentanteLegal);

        builder.Property(d => d.FechaCreacion).HasColumnType("date");

        builder.HasOne(d => d.Municipios).WithMany(d => d.Empresas).HasForeignKey(d => d.IdMun);
    }
}