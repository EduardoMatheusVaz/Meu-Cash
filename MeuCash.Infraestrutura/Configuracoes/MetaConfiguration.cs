using MeuCash.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infraestrutura.Configuracoes
{
    public class MetaConfiguration : IEntityTypeConfiguration<Meta>
    {
        public void Configure(EntityTypeBuilder<Meta> builder)
        {
            builder
                .ToTable("tab_Meta")
                .HasKey(i => i.Id);

            builder
                .Property(d => d.Nome)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(100)");

            builder
                .Property(d => d.Descricao)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(500)");

            builder
                .HasOne(u => u.Usuario)
                .WithMany(m => m.Metas)
                .HasForeignKey(u => u.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasOne(c => c.Conta)
                .WithMany(m => m.Metas)
                .HasForeignKey(i => i.IdConta)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.Valor)
                .HasColumnType("DECIMAL(18,2)");
        }
    }
}
