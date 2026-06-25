namespace MeuCash.Application.DTOs.View_Models
{
    public class MetaDetalhesViewModel
    {
        public MetaDetalhesViewModel(
            int id, 
            string nome, 
            string? descricao, 
            int idUsuario, 
            int idConta, 
            decimal valor, 
            DateTime dataCriacao, 
            DateTime? dataLimite)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            IdUsuario = idUsuario;
            IdConta = idConta;
            Valor = valor;
            DataCriacao = dataCriacao;
            DataLimite = dataLimite;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdConta { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataLimite { get; private set; }
    }
}
