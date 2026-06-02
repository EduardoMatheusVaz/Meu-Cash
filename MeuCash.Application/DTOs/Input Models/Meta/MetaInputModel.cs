namespace MeuCash.Application.DTOs.Input_Models
{
    public class MetaInputModel
    {
        public MetaInputModel(
            string nome, 
            string? descricao, 
            int idUsuario, 
            int idConta, 
            decimal valor,
            DateTime? dataLimite)
        {
            Nome = nome;
            Descricao = descricao;
            IdUsuario = idUsuario;
            IdConta = idConta;
            Valor = valor;
            DataLimite = dataLimite;
        }

        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public int IdUsuario { get; set; }
        public int IdConta { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataLimite { get; set; }
    }
}
