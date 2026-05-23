namespace MeuCash.Application.DTOs.View_Models
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }
    }
}
