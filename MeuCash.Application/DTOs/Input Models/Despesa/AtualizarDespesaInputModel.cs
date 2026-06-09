namespace MeuCash.Application.DTOs.Input_Models
{
    public class AtualizarDespesaInputModel
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
