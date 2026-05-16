namespace MeuCash.Core.Entidades
{
    public sealed class Categoria : BaseEntity
    {
        public Categoria(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }


        // Propriedades de navegação
        public ICollection<Despesa> Despesas { get; private set; }


        public void AtualizarCategoria(string nomeCategoria)
        {
            Nome = nomeCategoria;
        }
    }
}
