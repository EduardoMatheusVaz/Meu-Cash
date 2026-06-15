namespace MeuCash.Core.Exceptions
{
    public class ContaException : Exception
    {
        public ContaException(string message) : base(message)
        {
            
        }
    }

    public class ContaNaoEncontradaException : ContaException
    {
        public ContaNaoEncontradaException(int id) : base($@"Nenhuma conta com Id {id} foi encontrada")
        {
            
        }
    }

    public class ContaInativaException : ContaException
    {
        public ContaInativaException(int id) : base($@"A conta com Id {id} já está inativa no sistema")
        {

        }
    }

    public class ContaAtivaException : ContaException
    {
        public ContaAtivaException(int id) : base($@"A conta com Id {id} já está ativa no sistema")
        {

        }
    }
}
