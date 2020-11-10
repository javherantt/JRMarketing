using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.IdCliente)
                   .HasName("PK_IDCLIENTE");

            builder.ToTable("Cliente");

            builder.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("ID_Cliente");

            builder.Property(e => e.FinContrato).HasColumnType("datetime");

            builder.Property(e => e.TipoContrato)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.HasOne(d => d.IdClienteNavigation)
                .WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDCLIENTE");
        }
    }
}
