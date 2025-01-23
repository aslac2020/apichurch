using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackChurch.Data
{
    public class IgrejasCongregacionaisRepository : IIgrejasCongregacionaisRepository
    {
        private readonly string connectionString;
        private readonly IgrejasCongregacionaisQueries igrejaQueries;
        private readonly EnderecoIgrejasQueries enderecoIgrejasQueries;

        public IgrejasCongregacionaisRepository (IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            igrejaQueries = new IgrejasCongregacionaisQueries();
            enderecoIgrejasQueries = new EnderecoIgrejasQueries();
        }

        public async Task<IList<IgrejaCongregacionaisSemEndereco>> ObterIgrejasCongregacaos()
        {
            string query = igrejaQueries.BuscarIgrejas;

            await using (var con = new SqlConnection(connectionString))
            {
                return (await con.QueryAsync<IgrejaCongregacionaisSemEndereco>(query).ConfigureAwait(false)).AsList();
            }
        }

         public async Task<IgrejasCongregacionais> ObterIgrejaCongregacaoPorId(int id)
         {
            string query = igrejaQueries.BuscarPorUmaIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
               var igreja = await connection.QueryFirstOrDefaultAsync<IgrejasCongregacionais>(query, new {IdIgrejaCongregacao = id});

                if( igreja != null && igreja.IdEndereco != 0 )
                {
                    string enderecoQuery = enderecoIgrejasQueries.BuscarEnderecoIgrejaId;
                    igreja.EnderecoDaIgreja = await connection.QueryFirstOrDefaultAsync<EnderecoCongregacao>(enderecoQuery, new {IdEndereco = igreja?.IdEndereco});
                }
               

               return igreja;
            }
         }


         public async Task<bool> CriarIgrejaCongregacao(IgrejasCongregacionais igreja)
         {
            string query = igrejaQueries.InserirIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, igreja)
                    .ConfigureAwait(false);
                return retorno > 0;
            }
         }

        public async Task<bool> AtualizarIgrejaCongregacao(IgrejasCongregacionais igreja)
        {
            string query = igrejaQueries.AtualizarIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, igreja).ConfigureAwait(false);
                return retorno > 0;
            }
        }


        public async Task<bool> DeletarIgrejaCongregacao(int id)
        {
            string query = igrejaQueries.DeletarIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, new { IdIgreja = id }).ConfigureAwait(false);
                return retorno > 0;
            }
        }
    }
}
