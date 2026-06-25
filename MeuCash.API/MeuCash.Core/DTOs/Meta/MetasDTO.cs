namespace MeuCash.Core.DTOs
{
    public class MetasDTO
    {
        public MetasDTO(
            int id, 
            string nome, 
            int idConta, 
            decimal valor)
        {
            Id = id;
            Nome = nome;
            IdConta = idConta;
            Valor = valor;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int IdConta { get; private set; }
        public decimal Valor { get; private set; }
    }
}
