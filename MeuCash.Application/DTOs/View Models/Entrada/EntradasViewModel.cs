namespace MeuCash.Application.DTOs.View_Models
{
    public class EntradasViewModel
    {
        public EntradasViewModel(
            int id, 
            int idConta, 
            decimal valor, 
            DateTime data)
        {
            Id = id;
            IdConta = idConta;
            Valor = valor;
            Data = data;
        }

        public int Id { get; private set; }
        public int IdConta { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
    }
}
