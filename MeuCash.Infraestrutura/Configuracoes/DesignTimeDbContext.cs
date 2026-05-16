using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeuCash.Infraestrutura.Configuracoes
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<MeuCashDbContext>
    {
        public MeuCashDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeuCashDbContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-BPQKIBEO\\SQLSERVER2022;Database=Meu_Cash;User Id=sa;Password=Mortadela1!;TrustServerCertificate=True");
            
            return new MeuCashDbContext(optionsBuilder.Options);
        }
    }
}
