namespace MeuCash.Core.DTOs.Despesa
{
    public class DespesaDetalhesDTO
    {
        public DespesaDetalhesDTO(
            int id, 
            int idConta, 
            string nomeCategoria, 
            decimal valor, 
            DateTime dataDespesa,
            string descricao)
        {
            Id = id;
            IdConta = idConta;
            NomeCategoria = nomeCategoria;
            Valor = valor;
            DataDespesa = dataDespesa;
            Descricao = descricao;
        }

        public int Id { get; private set; }
        public int IdConta { get; private set; }
        public string NomeCategoria { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataDespesa { get; private set; }
        public string Descricao { get; private set; }
    }
}
