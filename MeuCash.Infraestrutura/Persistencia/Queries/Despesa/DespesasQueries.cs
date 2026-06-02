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
	                             WHEN IdCategoria = 1 THEN 'Alimentação'
	                             WHEN IdCategoria = 2 THEN 'Moradia'
	                             WHEN  IdCategoria = 3 THEN 'Transporte' 
	                             WHEN IdCategoria = 4 THEN 'Saúde'
	                             WHEN IdCategoria = 5 THEN 'Educação'
	                             WHEN  IdCategoria = 6 THEN 'Lazer'
	                             WHEN  IdCategoria = 7 THEN 'Tecnologia'
	                             WHEN  IdCategoria = 8 THEN 'Compras'
	                             WHEN  IdCategoria = 9 THEN 'Serviços'
	                             WHEN  IdCategoria = 10 THEN 'Assinaturas'
	                             WHEN  IdCategoria = 11 THEN 'Investimentos'
	                             WHEN  IdCategoria = 12 THEN 'Impostos'
	                             WHEN  IdCategoria = 13 THEN 'Família'
	                             WHEN  IdCategoria = 14 THEN 'Pets'
	                             WHEN  IdCategoria = 15 THEN 'Viagens' 
	                             WHEN  IdCategoria = 16 THEN 'Emergências'
	                             WHEN  IdCategoria = 17 THEN 'Dívidas'
	                             WHEN  IdCategoria = 18 THEN 'Trabalho'
	                             WHEN IdCategoria = 19 THEN 'Presentes'
	                             WHEN IdCategoria = 20 THEN 'Outros'
                             ELSE 'Outros'
	                            END AS NomeCategoria,
                        Valor, 
                        DataDespesa, 
                        Descricao
                    FROM tab_Despesa
                    WHERE Id = {id};";
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
