using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>

{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.Property(d => d.Nombre).HasMaxLength(50);

        builder.HasOne(d => d.Paises).WithMany(d => d.Departamentos).HasForeignKey(d => d.IdPais);
    }
}
