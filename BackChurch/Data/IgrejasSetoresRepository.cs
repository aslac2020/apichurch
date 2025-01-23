using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackChurch.Data
{
    public class IgrejasSetoresRepository : IIgrejasSetoresRepository
    {
        private readonly string connectionString;
        private readonly IgrejasSetoresQueries igrejaQueries;
        private readonly EnderecoIgrejasQueries enderecoIgrejasQueries;

        public IgrejasSetoresRepository (IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            igrejaQueries = new IgrejasSetoresQueries();
            enderecoIgrejasQueries = new EnderecoIgrejasQueries();
        }

        public async Task<IList<IgrejaSetoresSemEndereco>> ObterIgrejasSetores()
        {
            string query = igrejaQueries.BuscarIgrejas;

            await using (var con = new SqlConnection(connectionString))
            {
                return (await con.QueryAsync<IgrejaSetoresSemEndereco>(query).ConfigureAwait(false)).AsList();
            }
        }

         public async Task<IgrejasSetores> ObterIgrejaSetorPorId(int id)
         {
            string query = igrejaQueries.BuscarPorUmaIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
               var igreja = await connection.QueryFirstOrDefaultAsync<IgrejasSetores>(query, new {IdIgrejaSetor = id});

                if( igreja != null && igreja.IdEndereco != 0 )
                {
                    string enderecoQuery = enderecoIgrejasQueries.BuscarEnderecoIgrejaId;
                    igreja.EnderecoDaIgreja = await connection.QueryFirstOrDefaultAsync<EnderecoSetores>(enderecoQuery, new {IdEndereco = igreja?.IdEndereco});
                }
               

               return igreja;
            }
         }


         public async Task<bool> CriarIgrejaSetor(IgrejasSetores igreja)
         {
            string query = igrejaQueries.InserirIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, igreja)
                    .ConfigureAwait(false);
                return retorno > 0;
            }
         }

        public async Task<bool> AtualizarIgrejaSetor(IgrejasSetores igreja)
        {
            string query = igrejaQueries.AtualizarIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, igreja).ConfigureAwait(false);
                return retorno > 0;
            }
        }


        public async Task<bool> DeletarIgrejaSetor(int id)
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
