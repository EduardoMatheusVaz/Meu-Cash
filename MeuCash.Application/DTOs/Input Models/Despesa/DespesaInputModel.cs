namespace MeuCash.Application.DTOs.Input_Models
{
    public class DespesaInputModel
    {
        public DespesaInputModel(
            int idConta, 
            int idCategoria, 
            decimal valor, 
            DateTime dataDespesa, 
            string descricao)
        {
            IdConta = idConta;
            IdCategoria = idCategoria;
            Valor = valor;
            DataDespesa = dataDespesa;
            Descricao = descricao;
        }

        public int IdConta { get; set; }
        public int IdCategoria { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDespesa { get; set; }
        public string Descricao { get; set; }
    }
}
