namespace MeuCash.Core.Entidades
{
    public sealed class Usuario : BaseEntity
    {

        public Usuario(
            string nome,
            string userName,
            string senha,
            string email,
            string numeroCelular)
        {
            Nome = nome;
            UserName = userName;
            Senha = senha;
            Email = email;
            NumeroCelular = numeroCelular;

            Ativar();
        }

        public string Nome { get; private set; }
        public string UserName { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public string NumeroCelular { get; private set; }


        // Propriedades de navegação
        public Conta Conta { get; private set; }
        public ICollection<Meta> Metas { get; private set; }
        

        public void AtualizarUsuario(string nome, string username, string senha, string email, string numeroCelular)
        {
            Nome = nome;
            UserName = username;
            Senha = senha;
            Email = email;
            NumeroCelular = numeroCelular;
        }
    }
}
