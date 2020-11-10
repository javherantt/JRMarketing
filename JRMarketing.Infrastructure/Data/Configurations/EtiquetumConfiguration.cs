using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class EtiquetumConfiguration : IEntityTypeConfiguration<Etiquetum>
    {
        public void Configure(EntityTypeBuilder<Etiquetum> builder)
        {
            builder.HasKey(e => e.IdEtiqueta)
                                .HasName("PK_IDETIQUETA");

            builder.Property(e => e.IdEtiqueta).HasColumnName("ID_Etiqueta");

            builder.Property(e => e.NombreEtiqueta)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
