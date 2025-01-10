using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackChurch.Data
{
    public class EnderecosMembrosRepository : IEnderecosMembrosRepository
    {
        private readonly string connectionString;
        private readonly EnderecosMembrosQueries enderecosMembrosQueries;
        public EnderecosMembrosRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            enderecosMembrosQueries = new EnderecosMembrosQueries();
        }

        public async Task<EnderecosMembros> ObterEnderecosMembrosPorId(int id)
        {
            var query = enderecosMembrosQueries.BuscarEnderecoMembrosId;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<EnderecosMembros>(query, new { IdEndereco = id }).ConfigureAwait(false);
            }
        }

        public async Task<IList<EnderecosMembros>> ObterEnderecosMembros()
        {
            var query = enderecosMembrosQueries.BuscarEnderecoMembros;

            await using (var con = new SqlConnection(connectionString))
            {
                return (await con.QueryAsync<EnderecosMembros>(query).ConfigureAwait(false)).AsList();
            }
        }

        public async Task<bool> CriarEnderecosMembros(EnderecosMembros enderecosMembros)
        {
            var query = enderecosMembrosQueries.InserirEnderecoMembros;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, enderecosMembros).ConfigureAwait(false) > 0;
            }
        }

        public async Task<bool> AtualizarEnderecosMembros(EnderecosMembros enderecosMembros)
        {
            var query = enderecosMembrosQueries.AtualizarEnderecoMembros;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, enderecosMembros).ConfigureAwait(false) > 0;
            }
        }

 
        public async Task<bool> DeletarEnderecosMembros(int id)
        {
            var query = enderecosMembrosQueries.DeletarEnderecoMembros;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query,new { IdEndereco = id }).ConfigureAwait(false) > 0;
            }
        }
    }
       
}
