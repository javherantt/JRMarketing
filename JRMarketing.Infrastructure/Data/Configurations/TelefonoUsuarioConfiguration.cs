using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class TelefonoUsuarioConfiguration : IEntityTypeConfiguration<TelefonoUsuario>
    {
        public void Configure(EntityTypeBuilder<TelefonoUsuario> builder)
        {
            builder.ToTable("TelefonoUsuario");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.Property(e => e.NumeroUsuario)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.TelefonoUsuario)
                .HasForeignKey<TelefonoUsuario>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TELEFONOUSUARIO");
        }
    }
}
