namespace MeuCash.Application.DTOs.View_Models
{
    public class ContaDetalhesIdViewModel
    {
        public ContaDetalhesIdViewModel(
            int idConta,
            int idUsuario, 
            string nomeUsuario, 
            decimal saldoAtual)
        {
            Id = idConta;
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            SaldoAtual = saldoAtual;
        }

        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public string NomeUsuario { get; private set; }
        public decimal SaldoAtual { get; private set; }
    }
}
