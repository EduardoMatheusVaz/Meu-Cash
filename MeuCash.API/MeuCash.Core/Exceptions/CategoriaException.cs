namespace MeuCash.Core.Exceptions
{
    public class CategoriaException : Exception
    {
        public CategoriaException(string message) : base(message)
        {
            
        }
    }

    public class CategoriaNaoEncontradaException : CategoriaException
    {
        public CategoriaNaoEncontradaException(int id) : base($@"Nenhuma categoria encontrada para o Id {id}")
        {
            
        }
    }

    public class CategoriaAtivaException : CategoriaException
    {
        public CategoriaAtivaException(int id) : base($@"A categoria do Id {id} já está ativa no sistema")
        {
            
        }
    }

    public class CategoriaInativaException : CategoriaException
    {
        public CategoriaInativaException(int id) : base($@"A categoria do Id {id} já está inativa no sistema")
        {

        }
    }
}
