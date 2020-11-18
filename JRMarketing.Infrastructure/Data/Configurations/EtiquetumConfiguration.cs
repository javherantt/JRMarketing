using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class EtiquetumConfiguration : IEntityTypeConfiguration<Etiquetum>
    {
        public void Configure(EntityTypeBuilder<Etiquetum> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.Property(e => e.NombreEtiqueta)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");
        }
    }
}
