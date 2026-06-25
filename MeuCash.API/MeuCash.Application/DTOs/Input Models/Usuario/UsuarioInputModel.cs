namespace MeuCash.Application.DTOs.Input_Models
{
    public class UsuarioInputModel
    {
        public UsuarioInputModel(
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

        public string Nome { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string NumeroCelular { get; set; }
    }
}
