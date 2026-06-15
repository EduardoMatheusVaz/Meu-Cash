namespace MeuCash.Core.Exceptions
{
    public  class UsuarioException : Exception
    {
        public UsuarioException(string message) : base(message)
        {

        }
    }

    public class UsuarioEmailCadastradoException : UsuarioException
    {
        public UsuarioEmailCadastradoException() : base("Este email já está cadastro no sistema")
        {

        }
    }

    public class UsuarioNaoEncontradoException : UsuarioException
    {
        public UsuarioNaoEncontradoException(int id) : base($@"Nenhum usuário encontrado para o Id {id}")
        {

        }
    }

    public class UsuarioUsernameJaCadastradoException : UsuarioException
    {
        public UsuarioUsernameJaCadastradoException() : base("Este username já está cadastro no sistema")
        {

        }
    }

    public class UsuarioInvalidoException : UsuarioException
    {
        public UsuarioInvalidoException() : base("Usuário inválido para cadastro, revise os dados fornecidos e tente novamente")
        {

        }
    }

    public class UsuarioInativadoException : UsuarioException
    {
        public UsuarioInativadoException(int id) : base($@"Usuário {id} está inativo")
        {

        }
    }

    public class UsuarioAtivoException : UsuarioException
    {
        public UsuarioAtivoException(int id) : base($@"Usuário {id} está ativo")
        {

        }
    }
}
