using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BackChurch.Data
{
    public class FrequenciaRepository : IFrequenciaRepository
    {
        private readonly string connectionString;
        private readonly FrequenciaQueries frequenciaQueries;
        private readonly EventosQueries eventosQueries;

        public FrequenciaRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            frequenciaQueries = new FrequenciaQueries();
            eventosQueries = new EventosQueries();
        }
        public async Task<Frequencia> ObterFrequenciaPorId(int id)
        {
           var query = frequenciaQueries.BuscarFrequenciaPorId;

            await using (var con = new SqlConnection(connectionString))
            {
               var frequencia = await con.QueryFirstOrDefaultAsync<Frequencia>(query, new { IdFrequencia = id });
                
                if(frequencia != null && frequencia?.IdEvento != 0 || frequencia?.IdMembro != 0)
                { 
                   string eventosQuery = eventosQueries.BuscarEventoPorId;
                   frequencia.EventosDoDia = await con.QueryFirstOrDefaultAsync<EventosIgreja>(eventosQuery, new { IdEvento= frequencia?.IdEvento });
                }

                return frequencia;
 
            }
        }

        public async Task<IList<Frequencia>> ObterFrequencias()
        {
            string query = frequenciaQueries.BuscarFrequencias;

            await using (var con = new SqlConnection(connectionString))
            {
                return (await con.QueryAsync<Frequencia>(query).ConfigureAwait(false)).AsList();
            }
        }

         public async Task<bool> CriarFrequencia(Frequencia frequencia)
         {
             var query = frequenciaQueries.InserirFrequencia;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, frequencia).ConfigureAwait(false) > 0;
            }
         }


        public async Task<bool> AtualizarFrequencia(Frequencia frequencia)
        {
           var query = frequenciaQueries.AtualizarFrequencia;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, frequencia).ConfigureAwait(false) > 0;
            }
        }

       

        public async Task<bool> DeletarFrequencia(int id)
        {
            var query = frequenciaQueries.DeletarFrequencia;

            await using (var con = new SqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, new { IdFrequencia = id }).ConfigureAwait(false) > 0;
            }
        }

        
    }
}
