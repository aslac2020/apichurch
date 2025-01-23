using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackChurch.Data
{
    public class DizimosRepository : IDizimoRepository
    {
        private readonly string connectionString;
        private readonly DizimosQueries dizimosQueries;
        private readonly MembrosQueries membrosQueries;

        public DizimosRepository(IConfiguration configuration)
        {
           connectionString = configuration.GetConnectionString("DefaultConnection");
           dizimosQueries = new DizimosQueries();
           membrosQueries = new MembrosQueries();
        }

         public async Task<Dizimos> ObterDizimoPorId(int id)
         {
             var query = dizimosQueries.BuscarDizimosPorId;

            await using (var con = new SqlConnection(connectionString))
            {
                var dizimoMembro = await con.QueryFirstOrDefaultAsync<Dizimos>(query, new { IdDizimo = id }).ConfigureAwait(false);

                if (dizimoMembro != null)
                {
                    var queryMembro = membrosQueries.BuscarMembroPorId;
                    dizimoMembro.DizimoDoMembro = await con.QueryFirstOrDefaultAsync<RelatorioDizimoMembro>(queryMembro, new { IdMembro = dizimoMembro.IdMembro });
                }

                return dizimoMembro; 
            }
         }

        public async Task<IList<Dizimos>> ObterDizimos()
        {
             var query = dizimosQueries.BuscarDizimos;

            await using (var con = new SqlConnection(connectionString))
            {
                 return (await con.QueryAsync<Dizimos>(query).ConfigureAwait(false)).AsList();
            }

        }

         public async Task<bool> CriarDizimo(Dizimos dizimo)
         {
            var query = dizimosQueries.InserirDizimo;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, dizimo).ConfigureAwait(false) > 0;
            }
         }

        public async Task<bool> AtualizarDizimo(Dizimos dizimo)
        {
            var query = dizimosQueries.AtualizarDizimo;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, dizimo).ConfigureAwait(false) > 0;
            }
        }

       
        public async Task<bool> DeletarDizimo(int id)
        {
            var query = dizimosQueries.DeletarDizimo;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, new { IdDizimo = id }).ConfigureAwait(false) > 0;
            }
        }

       
    }
}
