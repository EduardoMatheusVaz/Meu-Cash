namespace MeuCash.Core.Exceptions
{
    public class MetasException : Exception
    {
        public MetasException(string message) : base(message)
        {
            
        }
    }

    public class MetaNaoEncontradaException : MetasException
    {
        public MetaNaoEncontradaException(int id) : base($@"Nenhuma meta correspondente ao Id {id} foi encontrado")
        {

        }
    }

    public class MetasNaoEncontradasContaException : MetasException
    {
        public MetasNaoEncontradasContaException(int id) : base($@"Nenhuma meta foi encontrada para a conta {id}")
        {

        }
    }

    public class MetaInativaException : MetasException
    {
        public MetaInativaException(int id) : base($@"A meta {id} já está inativada")
        {

        }
    }

    public class MetaAtivaException : MetasException
    {
        public MetaAtivaException(int id) : base($@"A meta {id} está ativa")
        {

        }
    }
}
