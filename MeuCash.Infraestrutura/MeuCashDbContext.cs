using MeuCash.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MeuCash.Infraestrutura
{
    public class MeuCashDbContext : DbContext
    {
        public MeuCashDbContext(DbContextOptions<MeuCashDbContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilder model = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
