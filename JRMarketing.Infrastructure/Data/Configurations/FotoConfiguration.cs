using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class FotoConfiguration : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.HasKey(e => e.IdFoto)
                    .HasName("PK_IDFOTO");

            builder.ToTable("Foto");

            builder.Property(e => e.IdFoto).HasColumnName("ID_Foto");

            builder.Property(e => e.CreatedAtPhoto).HasColumnType("datetime");

            builder.Property(e => e.FechaSubida).HasColumnType("datetime");

            builder.Property(e => e.FileName)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.IdPublicacionFoto).HasColumnName("Id_publicacionFoto");

            builder.Property(e => e.UpdatedAtPhoto).HasColumnType("datetime");

            builder.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(d => d.IdPublicacionFotoNavigation)
                .WithMany(p => p.Fotos)
                .HasForeignKey(d => d.IdPublicacionFoto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDPUBLICACIONFOTO");
        }
    }
}
