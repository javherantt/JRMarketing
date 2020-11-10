using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class RestauranteConfiguration : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.HasKey(e => e.IdRestaurante)
                    .HasName("PK_IDRESTAURANTE");

            builder.ToTable("Restaurante");

            builder.Property(e => e.IdRestaurante).HasColumnName("ID_Restaurante");

            builder.Property(e => e.CiudadR)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.CoidgoPostalR)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            builder.Property(e => e.ColoniaR)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.CreatedAtRestau).HasColumnType("datetime");

            builder.Property(e => e.DescripcionR)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.DireccionR)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.EstadoR)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.FotografiaR)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Horario)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.IdUsuarioR).HasColumnName("Id_usuarioR");

            builder.Property(e => e.NombreRestaurante)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedAtRestau).HasColumnType("datetime");

            builder.HasOne(d => d.IdUsuarioRNavigation)
                .WithMany(p => p.Restaurantes)
                .HasForeignKey(d => d.IdUsuarioR)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDUSUARIOR");
        }
    }
}
