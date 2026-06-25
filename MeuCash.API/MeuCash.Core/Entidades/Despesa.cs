namespace MeuCash.Core.Entidades
{
    public sealed class Despesa : BaseEntity
    {
        public Despesa(
            int idConta,
            int idCategoria,
            decimal valor,
            string? descricao)
        {
            IdConta = idConta;
            IdCategoria = idCategoria;
            Valor = valor;
            DataDespesa = DateTime.Now;
            Descricao = descricao;

            Ativar();
        }

        public int IdConta { get; private set; }
        public int IdCategoria { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataDespesa { get; private set; }
        public string? Descricao { get; private set; }


        // Propriedade de navegação
        public Conta Conta { get; private set; }
        public Categoria Categoria { get; private set; }


        public void AtualizarDespesa(int idCategoria, decimal valor, string? descricao)
        {
            IdCategoria = idCategoria;
            Valor = valor;
            Descricao = descricao;
        }

    }
}