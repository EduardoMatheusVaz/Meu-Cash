namespace MeuCash.Application.DTOs.Input_Models
{
    public class AtualizarUsuarioInputModel
    {
        public AtualizarUsuarioInputModel(
            int id,
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
        }

        public int Id { get; set; }
        public string Nome { get; private set; }
        public string UserName { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public string NumeroCelular { get; private set; }
    }
}
