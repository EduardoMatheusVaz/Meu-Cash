namespace MeuCash.Infraestrutura.Persistencia.Queries.Despesa
{
    public class DespesasQueries
    {
        public static string ObtemDespesaPeloId(int id)
        {
            return $@"SELECT 
                            Id, 
                            IdConta, 
                      CASE
                        WHEN 
                            IdCategoria = 1 THEN 'Alimentação', 
                            IdCategoria = 2 THEN 'Moradia', 
                            IdCategoria = 3 THEN 'Transporte', 
                            IdCategoria = 4 THEN 'Saúde', 
                            IdCategoria = 5 THEN 'Educação', 
                            IdCategoria = 6 THEN 'Lazer', 
                            IdCategoria = 7 THEN 'Tecnologia', 
                            IdCategoria = 8 THEN 'Compras', 
                            IdCategoria = 9 THEN 'Serviços', 
                            IdCategoria = 10 THEN 'Assinaturas', 
                            IdCategoria = 11 THEN 'Investimentos', 
                            IdCategoria = 12 THEN 'Impostos', 
                            IdCategoria = 13 THEN 'Família', 
                            IdCategoria = 14 THEN 'Pets', 
                            IdCategoria = 15 THEN 'Viagens', 
                            IdCategoria = 16 THEN 'Emergências', 
                            IdCategoria = 17 THEN 'Dívidas', 
                            IdCategoria = 18 THEN 'Trabalho', 
                            IdCategoria = 19 THEN 'Presentes', 
                            IdCategoria = 20 THEN 'Outros'
                        ELSE 'Outros'
                      END AS NomeCategoria  
                            Valor, 
                            DataDespesa, 
                            Descricao
                      FROM tab_Despesas
                      WHERE Id = {id}"
            ;
        }

        public static string ObtemDespesasPeloIdConta(int idConta)
        {
            return $@"SELECT Id, IdConta, Valor, DataDespesa
                      FROM tab_Despesas
                      WHERE IdConta = {idConta};"
            ;
        }

        public static string ObtemDespesas()
        {
            return $@"SELECT Id, IdConta, Valor, DataDespesa
                      FROM tab_Despesas;"
            ;
        }
    }
}
