using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration;
public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleado");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id);

        builder.HasIndex(d => d.IdEmp).IsUnique();
        builder.Property(d => d.IdEmp);

        builder.Property(d => d.Nombre);
        
        builder.Property(d => d.FechaIngreso).HasColumnType("date");

        builder.HasOne(d => d.Cargos).WithMany(d => d.Empleados).HasForeignKey(d => d.IdCargo);

        builder.HasOne(d => d.Municipios).WithMany(d => d.Empleados).HasForeignKey(d => d.IdMunicipio);
    }
}