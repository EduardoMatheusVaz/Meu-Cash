namespace MeuCash.Core.Entidades
{
    public sealed class Conta : BaseEntity
    {
        public Conta(int idUsuario, decimal saldoAtual)
        {
            IdUsuario = idUsuario;
            SaldoAtual = saldoAtual;

            Ativar();
        }

        public int IdUsuario { get; private set; }
        public decimal SaldoAtual { get; private set; }


        // Propriedades de navegação
        public Usuario UsuarioConta { get; private set; }
        public ICollection<Entrada> Entradas { get; private set; }
        public ICollection<Despesa> Despesas { get; private set; }
        public ICollection<Meta> Metas { get; private set; }


        public void AtualizarConta(decimal saldoAtual)
        {
            SaldoAtual = saldoAtual;
        }
    }
}