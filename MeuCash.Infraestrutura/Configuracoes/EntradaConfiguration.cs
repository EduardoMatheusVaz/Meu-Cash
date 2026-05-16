using MeuCash.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infraestrutura.Configuracoes
{
    public class EntradaConfiguration : IEntityTypeConfiguration<Entrada>
    {
        public void Configure(EntityTypeBuilder<Entrada> builder)
        {
            builder
                .ToTable("tab_Entrada")
                .HasKey(i => i.Id);

            builder
                .Property(d => d.Descricao)
                .HasColumnType("NVARCHAR(150)");

            builder
                .HasOne(c => c.Conta)
                .WithMany(e => e.Entradas)
                .HasForeignKey(c => c.IdConta)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.Valor)
                .HasColumnType("DECIMAL(18,2)");
        }
    }
}
