namespace MeuCash.Core.DTOs.Despesa
{
    public class DespesasDTO
    {
        public DespesasDTO(
            int id,
            int idConta, 
            decimal valor, 
            DateTime dataDespesa)
        {
            Id = id;
            IdConta = idConta;
            Valor = valor;
            DataDespesa = dataDespesa;
        }

        public int Id { get; set; }
        public int IdConta { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataDespesa { get; private set; }
    }
}
