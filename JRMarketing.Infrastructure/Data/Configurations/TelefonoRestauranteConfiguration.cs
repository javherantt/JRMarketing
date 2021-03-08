using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class TelefonoRestauranteConfiguration : IEntityTypeConfiguration<TelefonoRestaurante>
    {
        public void Configure(EntityTypeBuilder<TelefonoRestaurante> builder)
        {
            builder.ToTable("TelefonoRestaurante");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.Property(e => e.NumeroRestaurante)
                .IsRequired()
                .HasMaxLength(14)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");
    
        }
    }
}
