namespace MeuCash.Application.DTOs.Input_Models
{
    public class EntradaInputModel
    {
        public EntradaInputModel(
            int idConta, 
            decimal valor, 
            DateTime data, 
            string descricao)
        {
            IdConta = idConta;
            Valor = valor;
            Data = data;
            Descricao = descricao;
        }

        public int IdConta { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
