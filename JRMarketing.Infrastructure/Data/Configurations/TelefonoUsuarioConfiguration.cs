using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class TelefonoUsuarioConfiguration : IEntityTypeConfiguration<TelefonoUsuario>
    {
        public void Configure(EntityTypeBuilder<TelefonoUsuario> builder)
        {
            builder.HasKey(e => e.IdTelefonoUser)
                   .HasName("PK_TELEFONOUSUARIO");

            builder.ToTable("TelefonoUsuario");

            builder.Property(e => e.IdTelefonoUser)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_TelefonoUser");

            builder.Property(e => e.NumeroUsuario)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false);

            builder.HasOne(d => d.IdTelefonoUserNavigation)
                .WithOne(p => p.TelefonoUsuario)
                .HasForeignKey<TelefonoUsuario>(d => d.IdTelefonoUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TELEFONOUSUARIO");
        }
    }
}
