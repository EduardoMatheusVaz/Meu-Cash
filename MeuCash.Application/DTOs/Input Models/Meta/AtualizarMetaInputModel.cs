namespace MeuCash.Application.DTOs.Input_Models
{
    public class AtualizarMetaInputModel
    {
        public AtualizarMetaInputModel(
            int id,
            string nome, 
            string descricao, 
            decimal valor,
            DateTime dataLimite)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            DataLimite = dataLimite;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLimite { get; set; }
    }
}
