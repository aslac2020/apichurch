using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackChurch.Data
{
    public class EventoRepository : IEventoRepository
    {
          private readonly string connectionString;
          private readonly EventosQueries eventoQueries;

        public EventoRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            eventoQueries = new EventosQueries();
        }

         public async Task<Eventos> ObterEventoPorId(int id)
         {
            var query = eventoQueries.BuscarEventoPorId;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<Eventos>(query, new { IdEvento = id }).ConfigureAwait(false); 
            }
         }

        public async Task<IList<Eventos>> ObterEventos()
        {
             var query = eventoQueries.BuscarEventos;

            await using (var con = new SqlConnection(connectionString))
            {
                 return (await con.QueryAsync<Eventos>(query).ConfigureAwait(false)).AsList();
            }
        }

         public async Task<bool> CriarEvento(Eventos evento)
         {
            var query = eventoQueries.InserirEvento;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, evento).ConfigureAwait(false) > 0;
            }
         }

        public async Task<bool> AtualizarEvento(Eventos evento)
        {
            var query = eventoQueries.AtualizarEvento;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, evento).ConfigureAwait(false) > 0;
            }
        }


        public async Task<bool> DeletarEvento(int id)
        {
            var query = eventoQueries.DeletarEvento;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, new { IdEvento = id }).ConfigureAwait(false) > 0;
            }
        }

       
    }
}
