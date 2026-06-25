using MeuCash.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infraestrutura.Configuracoes
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .ToTable("tab_Usuarios")
                .HasKey(i => i.Id);

            builder
                .Property(n => n.Nome)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(200)");

            builder
                .Property(u => u.UserName)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(80)");

            builder
                .Property(s => s.Senha)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(50)");

            builder
                .Property(e => e.Email)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(300)");

            builder
                .Property(n => n.NumeroCelular)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(24)");
        }
    }
}
