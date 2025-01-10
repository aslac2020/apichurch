using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackChurch.Data
{
    public class HistoricoMinisterialRepository : IHistoricoMinisterialRepository
    {
       private readonly string connectionString;
       private readonly HistoricoMinisterialQueries historicoMinisterialQueries;

        public HistoricoMinisterialRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            historicoMinisterialQueries = new HistoricoMinisterialQueries();
        }

         public async Task<IList<HistoricoMinisterial>> ObterHistoricoMinisterial()
         {
            var query = historicoMinisterialQueries.BuscarHistoricoMinisterial;

            await using (var con = new SqlConnection(connectionString))
            {
                return (await con.QueryAsync<HistoricoMinisterial>(query).ConfigureAwait(false)).AsList();
            }
         }

        public async Task<HistoricoMinisterial> ObterHistoricoMinisterialPorId(int id)
        {
            var query = historicoMinisterialQueries.BuscarHistoricoMinisterialPorId;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<HistoricoMinisterial>(query, new { IdHistorico = id }).ConfigureAwait(false);
            }
        }

        public async Task<bool> CriarHistoricoMinisterial(HistoricoMinisterial historicoMinisterial)
        {
            var query = historicoMinisterialQueries.InserirHistoricoMinisterial;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, historicoMinisterial).ConfigureAwait(false) > 0;
            }
        }


        public async Task<bool> AtualizarHistoricoMinisterial(HistoricoMinisterial historicoMinisterial)
        {
            var query = historicoMinisterialQueries.AtualizarHistoricoMinisterial;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, historicoMinisterial).ConfigureAwait(false) > 0;
            }
        }


        public async Task<bool> DeletarHistoricoMinisterial(int id)
        {
            var query = historicoMinisterialQueries.DeletarHistoricoMinisterial;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, new { IdHistorico = id }).ConfigureAwait(false) > 0;
            }
        }

       
    }
}
