namespace MeuCash.Application.DTOs.Input_Models
{
    public class ContaInputModel
    {
        public ContaInputModel(int idUsuario, decimal saldoAtual)
        {
            IdUsuario = idUsuario;
            SaldoAtual = saldoAtual;
        }

        public int IdUsuario { get;  set; }
        public decimal SaldoAtual { get;  set; }
    }
}
