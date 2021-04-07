using JRMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JRMarketing.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            builder.Property(e => e.FinContrato).HasColumnType("datetime");

            builder.Property(e => e.TipoContrato)
                .HasMaxLength(10)
                .IsUnicode(false);
            

            builder.HasOne(d => d.IdNavigation)
                .WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IDCLIENTE");
            builder.Ignore(e => e.CreatedAt);
            builder.Ignore(e => e.UpdatedAt);
        }
    }
}
