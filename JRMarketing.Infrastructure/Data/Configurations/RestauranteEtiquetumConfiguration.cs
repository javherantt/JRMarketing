using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class RestauranteEtiquetumConfiguration : IEntityTypeConfiguration<RestauranteEtiquetum>
    {
        public void Configure(EntityTypeBuilder<RestauranteEtiquetum> builder)
        {
            builder.HasKey(e => new { e.IdRestauranteEtiq, e.IdEtiquetaRestau })
                   .HasName("PK_RESTAURANTEETIQUETA");

            builder.Property(e => e.IdRestauranteEtiq).HasColumnName("ID_RestauranteEtiq");

            builder.Property(e => e.IdEtiquetaRestau).HasColumnName("ID_EtiquetaRestau");

            builder.HasOne(d => d.IdEtiquetaRestauNavigation)
                .WithMany(p => p.RestauranteEtiqueta)
                .HasForeignKey(d => d.IdEtiquetaRestau)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ETIQUETARESTAU");

            builder.HasOne(d => d.IdRestauranteEtiqNavigation)
                .WithMany(p => p.RestauranteEtiqueta)
                .HasForeignKey(d => d.IdRestauranteEtiq)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESTAURANTEETIQUETA");
            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.CreatedAt);
            builder.Ignore(e => e.UpdatedAt);
        }
    }
}
