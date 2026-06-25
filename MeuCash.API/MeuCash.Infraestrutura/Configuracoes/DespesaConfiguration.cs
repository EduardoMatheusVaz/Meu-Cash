using MeuCash.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infraestrutura.Configuracoes
{
    public class DespesaConfiguration : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder
                .ToTable("tab_Despesa")
                .HasKey(i => i.Id);

            builder
                .Property(d => d.Descricao)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(150)");

            builder
                .HasOne(c => c.Conta)
                .WithMany(d => d.Despesas)
                .HasForeignKey(i => i.IdConta)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Categoria)
                .WithMany(d => d.Despesas)
                .HasForeignKey(i => i.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.Valor)
                .HasColumnType("DECIMAL(18,2)");
        }
    }
}
