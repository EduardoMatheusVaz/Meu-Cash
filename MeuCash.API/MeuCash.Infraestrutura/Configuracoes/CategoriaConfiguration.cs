using MeuCash.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuCash.Infraestrutura.Configuracoes
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder
                .ToTable("tab_Categoria")
                .HasKey(i => i.Id);

            builder
                .Property(d => d.Nome)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(50)");
        }
    }
}
