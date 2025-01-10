using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackChurch.Data
{
    public class IgrejaRepository : IIgrejaRepository
    {
        private readonly string connectionString;
        private readonly IgrejaQueries igrejaQueries;
        private readonly EnderecoIgrejasQueries enderecoIgrejasQueries;

        public IgrejaRepository (IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            igrejaQueries = new IgrejaQueries();
            enderecoIgrejasQueries = new EnderecoIgrejasQueries();
        }

        public async Task<IList<IgrejaSemEndereco>> ObterIgrejas()
        {
            string query = igrejaQueries.BuscarIgrejas;

            await using (var con = new SqlConnection(connectionString))
            {
                return (await con.QueryAsync<IgrejaSemEndereco>(query).ConfigureAwait(false)).AsList();
            }
        }

         public async Task<Igrejas> ObterIgrejaPorId(int id)
         {
            string query = igrejaQueries.BuscarPorUmaIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
               var igreja = await connection.QueryFirstOrDefaultAsync<Igrejas>(query, new {IdIgreja = id});

                if( igreja != null && igreja.IdEndereco != 0 )
                {
                    string enderecoQuery = enderecoIgrejasQueries.BuscarEnderecoIgrejaId;
                    igreja.EnderecoDaIgreja = await connection.QueryFirstOrDefaultAsync<Endereco>(enderecoQuery, new {IdEndereco = igreja?.IdEndereco});
                }
               

               return igreja;
            }
         }


         public async Task<bool> CriarIgreja(Igrejas igreja)
         {
            string query = igrejaQueries.InserirIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, igreja)
                    .ConfigureAwait(false);
                return retorno > 0;
            }
         }

        public async Task<bool> AtualizarIgreja(Igrejas igreja)
        {
            string query = igrejaQueries.AtualizarIgreja;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, igreja).ConfigureAwait(false);
                return retorno > 0;
            }
        }

       

        public async Task<bool> DeletarIgreja(int id)
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
