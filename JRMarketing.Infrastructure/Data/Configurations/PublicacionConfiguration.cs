using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class PublicacionConfiguration : IEntityTypeConfiguration<Publicacion>
    {
        public void Configure(EntityTypeBuilder<Publicacion> builder)
        {
            builder.HasKey(e => e.IdPublicacion)
                    .HasName("PK_IDPUBLICACION");

            builder.ToTable("Publicacion");

            builder.Property(e => e.IdPublicacion).HasColumnName("ID_Publicacion");

            builder.Property(e => e.DescripcionP)
                .IsRequired()
                .HasMaxLength(600)
                .IsUnicode(false);

            builder.Property(e => e.IdRestaurantePubli).HasColumnName("Id_restaurantePubli");

            builder.HasOne(d => d.IdRestaurantePubliNavigation)
                .WithMany(p => p.Publicacions)
                .HasForeignKey(d => d.IdRestaurantePubli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDRESTAURANTEPUBLIC");
        }
    }
}
