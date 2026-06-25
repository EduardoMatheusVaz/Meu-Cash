namespace MeuCash.Core.Exceptions
{
    public class DespesaException : Exception
    {
        public DespesaException(string message) : base(message)
        {
            
        }
    }

    public class DespesaNaoEncontradaException : DespesaException
    {
        public DespesaNaoEncontradaException(int id) : base($@"A despesa {id} não foi encontrada")
        {

        }
    }

    public class DespesaIdContaNaoEncontradaException : DespesaException
    {
        public DespesaIdContaNaoEncontradaException(int id) : base($@"Nenhuma despesa foi encontrada para a conta {id}")
        {

        }
    }

    public class DespesaInativaException : DespesaException
    {
        public DespesaInativaException(int id) : base($@"A despesa {id} já está inativa")
        {

        }
    }

    public class DespesaAtivaException : DespesaException
    {
        public DespesaAtivaException(int id) : base($@"A despesa {id} está ativa")
        {

        }
    }
}
