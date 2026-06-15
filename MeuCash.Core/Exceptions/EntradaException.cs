namespace MeuCash.Core.Exceptions
{
    public class EntradaException : Exception
    {
        public EntradaException(string message) : base(message)
        {
            
        }
    }

    public class EntradaIdNaoEncontradaException : EntradaException
    {
        public EntradaIdNaoEncontradaException(int id) : base($@"Nenhuma entrada foi encontrada para o Id: {id}")
        {

        }
    }

    public class EntradasNaoEncontradasContaException : EntradaException
    {
        public EntradasNaoEncontradasContaException(int id) : base($@"Nenhuma entrada foi encontrada para a conta: {id}")
        {

        }
    }

    public class EntradaInativadaException : EntradaException
    {
        public EntradaInativadaException(int id) : base($@"A entrada de Id {id} está inativa")
        {

        }
    }

    public class EntradaAtivaException : EntradaException
    {
        public EntradaAtivaException(int id) : base($@"A entrada de Id {id} está ativa")
        {

        }
    }
}
