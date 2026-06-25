namespace MeuCash.Infraestrutura.Persistencia.Queries.Conta
{
    public class ContaQueries
    {
        public static string ObtemContaPeloId(int id)
        {
            return $@"SELECT c.Id,
                             c.IdUsuario,
                             u.Nome AS NomeUsuario,
                             c.SaldoAtual
                      FROM tab_Conta c
                      LEFT JOIN tab_Usuarios u
                        ON c.IdUsuario = u.Id
                      WHERE u.Id = {id};
            ";
        }

        public static string ObtemContas()
        {
            return $@"SELECT c.Id,
                             c.IdUsuario,
                             u.Nome AS NomeUsuario,
                             c.SaldoAtual
                      FROM tab_Conta c
                      LEFT JOIN tab_Usuarios u
                        ON c.IdUsuario = u.Id
                     WHERE c.Ativo = 1;
            ";
        }

        public static string ObtemContasInativas()
        {
            return $@"SELECT c.Id,
                             c.IdUsuario,
                             u.Nome AS NomeUsuario,
                             c.SaldoAtual
                      FROM tab_Conta c
                      LEFT JOIN tab_Usuarios u
                        ON c.IdUsuario = u.Id
                     WHERE c.Ativo = 0;
            ";
        }
    }
}
