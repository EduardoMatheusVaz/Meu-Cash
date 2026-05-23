namespace MeuCash.Core.DTOs
{
    public class ContaDetalhesIdDTO
    {
        public ContaDetalhesIdDTO(
            int idConta, 
            int idUsuario, 
            string nomeUsuario, 
            decimal saldoAtual)
        {
            IdConta = idConta;
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            SaldoAtual = saldoAtual;
        }

        public int IdConta { get; private set; }
        public int IdUsuario { get; private set; }
        public string NomeUsuario { get; private set; }
        public decimal SaldoAtual { get; private set; }
    }
}
