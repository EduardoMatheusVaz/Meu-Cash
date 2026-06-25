namespace MeuCash.Core.Entidades
{
    public sealed class Entrada : BaseEntity
    {
        public Entrada(
            int idConta,
            decimal valor,
            DateTime data,
            string? descricao)
        {
            IdConta = idConta;
            Valor = valor;
            Data = data;
            Descricao = descricao;

            Ativar();
        }

        public int IdConta { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public string? Descricao { get; private set; }


        // Propriedades de navegação
        public Conta Conta { get; private set; }


        public void AtualizarEntrada(decimal valor, string descricao)
        {
            Valor = valor;
            Descricao = descricao;
        }
    }
}