namespace MeuCash.Application.DTOs.View_Models
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(
            int id, 
            string nome, 
            string email, 
            string numeroCelular)
        {
            Id = id;
            Nome = nome;
            Email = email;
            NumeroCelular = numeroCelular;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string NumeroCelular { get; private set; }
    }
}
