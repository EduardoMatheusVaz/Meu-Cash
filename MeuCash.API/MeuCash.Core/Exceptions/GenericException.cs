namespace MeuCash.Core.Exceptions
{
    public class GenericException : Exception
    {
        public GenericException(string message) : base(message)
        {
        }
    }

    public class RegistroIdEncontradoException : GenericException
    {
        public RegistroIdEncontradoException(int id) : base($"Registro com ID {id} não foi encontrado.")
        {   
        }
    }

    public class EntidadeInativaException : GenericException
    {
        public EntidadeInativaException(int id) : base($"Registro com ID {id} já está inativo.")
        {
        }
    }

    public class EntidadeAtivaException : GenericException
    {
        public EntidadeAtivaException(int id) : base($"Registro com ID {id} já está ativo.")
        {
        }
    }

    public class EntidadeJaExisteException : GenericException
    {
        public EntidadeJaExisteException() : base("Registro já existe no sistema")
        {
            
        }
    }

    public class OperacaoNaoPermitidaException : GenericException
    {
        public OperacaoNaoPermitidaException() : base("Você não tem permissão para realizar esta operação")
        {
            
        }
    }
}
