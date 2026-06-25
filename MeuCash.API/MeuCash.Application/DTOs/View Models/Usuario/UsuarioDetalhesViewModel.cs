namespace MeuCash.Application.DTOs.View_Models
{
    public class UsuarioDetalhesViewModel
    {
        public UsuarioDetalhesViewModel(
            int id,
            string nome, 
            string userName, 
            string senha, 
            string email, 
            string numeroCelular)
        {
            Id = id;
            Nome = nome;
            UserName = userName;
            Senha = senha;
            Email = email;
            NumeroCelular = numeroCelular;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string UserName { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public string NumeroCelular { get; private set; }
    }
}
