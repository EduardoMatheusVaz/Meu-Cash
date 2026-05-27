namespace MeuCash.Core.Entidades
{
    public sealed class Meta : BaseEntity
    {
        public Meta(
            string nome,
            string? descricao,
            int idUsuario,
            int idConta,
            decimal valor,
            DateTime? dataLimite)
        {
            Nome = nome;
            Descricao = descricao;
            IdUsuario = idUsuario;
            IdConta = idConta;
            Valor = valor;
            DataCriacao = DateTime.Now;
            DataLimite = dataLimite;
        }

        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdConta { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataLimite { get; private set; }


        // Propriedade de navegação
        public Usuario Usuario { get; private set; }
        public Conta Conta { get; private set; }


        public void AtualizarMeta(string nome, string descricao, int idUsuario, int idConta, decimal valor, DateTime dataLimite)
        {
            Nome = nome;
            Descricao = descricao;
            IdUsuario = idUsuario;
            IdConta= idConta;
            Valor = valor;
            DataLimite = dataLimite;
        }
    }
}