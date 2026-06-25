namespace MeuCash.Application.DTOs.View_Models
{
    public class EntradaDetalhesViewModel
    {
        public EntradaDetalhesViewModel(
            int id, 
            int idConta, 
            decimal valor, 
            DateTime data, 
            string descricao)
        {
            Id = id;
            IdConta = idConta;
            Valor = valor;
            Data = data;
            Descricao = descricao;
        }

        public int Id { get; private set; }
        public int IdConta { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
    }
}
