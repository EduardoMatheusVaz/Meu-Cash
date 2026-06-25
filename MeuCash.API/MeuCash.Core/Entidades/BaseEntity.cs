namespace MeuCash.Core.Entidades
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        
        public int Id { get; private set; }
        public bool Ativo { get; private set; }
        public string? MotivoExclusao { get; private set; }
        public DateTime? DataExclusao { get; private set; }

        public void Inativar(string motivoExclusao)
        {
            Ativo = false;
            MotivoExclusao = motivoExclusao;
            DataExclusao = DateTime.Now;
        }

        public void Ativar(string motivoExclusao)
        {
            Ativo = false;
            MotivoExclusao = motivoExclusao;
            DataExclusao = DateTime.Now;
        }

        public void Ativar()
        {
            Ativo = true;
            MotivoExclusao = string.Empty;
            DataExclusao = null;
        }
    }
}