using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infratructure.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id);

            builder.HasIndex(d => d.IdCliente).IsUnique();
            builder.Property(d => d.IdCliente);

            builder.Property(d => d.Nombre);

            builder.Property(d => d.FechaRegistro).HasColumnType("date");

            builder.HasOne(d => d.TipoPersonas).WithMany(d => d.Clientes).HasForeignKey(d => d.IdTipoPersona);

            builder.HasOne(d => d.Municipios).WithMany(d => d.Clientes).HasForeignKey(d => d.IdMunicipio);
        }
    }
}