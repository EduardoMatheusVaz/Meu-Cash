namespace MeuCash.Application.DTOs.Input_Models
{
    public class AtualizarCategoriaInputModel
    {
        public AtualizarCategoriaInputModel
        (
            int id, 
            string nome
        )
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
