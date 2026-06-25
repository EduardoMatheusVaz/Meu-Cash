namespace MeuCash.Application.DTOs.View_Models
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
    }
}
