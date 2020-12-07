using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class PublicacionConfiguration : IEntityTypeConfiguration<Publicacion>
    {
        public void Configure(EntityTypeBuilder<Publicacion> builder)
        {
            builder.ToTable("Publicacion");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.Property(e => e.Foto)
                .HasMaxLength(450)
                .IsUnicode(false);
                
            builder.Property(e => e.DescripcionP)
                .IsRequired()
                .HasMaxLength(600)
                .IsUnicode(false);

            builder.Property(e => e.IdRestaurantePubli).HasColumnName("Id_restaurantePubli");

            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");

            builder.HasOne(d => d.IdRestaurantePubliNavigation)
                .WithMany(p => p.Publicacions)
                .HasForeignKey(d => d.IdRestaurantePubli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDRESTAURANTEPUBLIC");
        }
    }
}
