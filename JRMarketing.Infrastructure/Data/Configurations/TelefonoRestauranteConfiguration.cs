using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class TelefonoRestauranteConfiguration : IEntityTypeConfiguration<TelefonoRestaurante>
    {
        public void Configure(EntityTypeBuilder<TelefonoRestaurante> builder)
        {
            builder.HasKey(e => e.IdTelefonoRestau)
                    .HasName("PK_IDTELEFONORESTAU");

            builder.ToTable("TelefonoRestaurante");

            builder.Property(e => e.IdTelefonoRestau)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_TelefonoRestau");

            builder.Property(e => e.NumeroRestaurante)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false);

            builder.HasOne(d => d.IdTelefonoRestauNavigation)
                .WithOne(p => p.TelefonoRestaurante)
                .HasForeignKey<TelefonoRestaurante>(d => d.IdTelefonoRestau)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDTELEFONORESTAU");
        }
    }
}
