using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackChurch.Data
{
    public class EnderecoIgrejaRepository : IEnderecoIgrejasRepository
    {
        private readonly string connectionString;
        private readonly EnderecoIgrejasQueries enderecoIgrejaasQueries;
        public EnderecoIgrejaRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            enderecoIgrejaasQueries = new EnderecoIgrejasQueries();
        }
        public async Task<EnderecoIgrejas> ObterEnderecoIgrejaPorId(int id)
        {
            var query = enderecoIgrejaasQueries.BuscarEnderecoIgrejaId;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<EnderecoIgrejas>(query, new { IdEndereco = id }).ConfigureAwait(false);
            }
        }

        public async Task<IList<EnderecoIgrejas>> ObterEnderecoIgrejas()
        {
            var query = enderecoIgrejaasQueries.BuscarEnderecoIgrejas;

            await using (var con = new SqlConnection(connectionString))
            {
                return (await con.QueryAsync<EnderecoIgrejas>(query).ConfigureAwait(false)).AsList();
            }
        }

        public async Task<bool> CriarEnderecoIgreja(EnderecoIgrejas enderecoIgrejas)
        {
            var query = enderecoIgrejaasQueries.InserirEnderecoIgreja;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, enderecoIgrejas).ConfigureAwait(false) > 0;
            }
        }


        public async Task<bool> AtualizarEnderecoIgreja(EnderecoIgrejas enderecoIgrejas)
        {
            var query = enderecoIgrejaasQueries.AtualizarEnderecoIgreja;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, enderecoIgrejas).ConfigureAwait(false) > 0;
            }
        }

   
        public async Task<bool> DeletarEnderecoIgreja(int id)
        {
            var query = enderecoIgrejaasQueries.DeletarEnderecoIgreja;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, new { IdEndereco = id }).ConfigureAwait(false) > 0;
            }
        }

        
    }
}
