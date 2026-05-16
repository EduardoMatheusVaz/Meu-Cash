using MeuCash.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infraestrutura.Configuracoes
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder
                .ToTable("tab_Conta")
                .HasKey(i => i.Id);

            builder
                .HasOne(u => u.UsuarioConta)
                .WithOne(c => c.Conta)
                .HasForeignKey<Conta>(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.SaldoAtual)
                .HasColumnType("DECIMAL(18,2)");
        }
    }
}
