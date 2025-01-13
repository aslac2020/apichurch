using BackChurch.Data.Queries;
using BackChurch.Domain;
using BackChurch.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using static BackChurch.Domain.MembroCadastroCompleto;

namespace BackChurch.Data
{
    public class MembrosRepository : IMembrosRepository
    {
        private readonly string connectionString;
        private readonly MembrosQueries membrosQueries;
        private readonly EnderecosMembrosQueries enderecosMembrosQueries;
        private readonly HistoricoMinisterialQueries historicoMinisterialQueries;
        private readonly IgrejaQueries igrejaQueries;

        public MembrosRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            membrosQueries = new MembrosQueries();
            enderecosMembrosQueries = new EnderecosMembrosQueries();
            historicoMinisterialQueries = new HistoricoMinisterialQueries();
            igrejaQueries = new IgrejaQueries();
        }

        public async Task<IList<Membros>> ObterMembros()
        {
            string query = membrosQueries.BuscarMembros;

            await using (var con = new SqlConnection(connectionString))
            {
                return (await con.QueryAsync<Membros>(query).ConfigureAwait(false)).AsList();
            }
        }

        public async Task<MembroCadastroCompleto> ObterMembroPorId(int id)
        {
            string query = membrosQueries.BuscarMembroPorId;

            await using (var connection = new SqlConnection(connectionString))
            {
                var membro = await connection.QueryFirstOrDefaultAsync<MembroCadastroCompleto>(query, new { IdMembro = id });

                if (membro != null && membro?.IdEndereco != 0 && membro.IdHistorico !=0 && membro.IdIgreja != 0)
                {
                    string enderecoQuery = enderecosMembrosQueries.BuscarEnderecoMembrosId;
                    membro.EnderecoDoMembro = await connection.QueryFirstOrDefaultAsync<EnderecoMembro>(enderecoQuery, new { IdEndereco = membro?.IdEndereco });

                    string historicoQuery = historicoMinisterialQueries.BuscarHistoricoMinisterialPorId;
                    membro.HistoricoMinisterialDoMembro = await connection.QueryFirstOrDefaultAsync<HistoricoMinisterialMembro>(historicoQuery, new { IdHistorico = membro?.IdHistorico });

                    string igrejaQuery = igrejaQueries.BuscarPorUmaIgreja;
                    membro.IgrejaDoMembro = await connection.QueryFirstOrDefaultAsync<IgrejaMembro>(igrejaQuery, new { IdIgreja = membro?.IdIgreja });

                }


                return membro;
            }
        }

        public async Task<bool> CriarMembro(Membros membros)
        {
            string query = membrosQueries.InserirMembros;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, membros)
                    .ConfigureAwait(false);
                return retorno > 0;
            }
        }

        public async Task<bool> AtualizarMembro(Membros membros)
        {
            string query = membrosQueries.AtualizarMembros;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, membros).ConfigureAwait(false);
                return retorno > 0;
            }
        }

        public async Task<bool> DeletarMembro(int id)
        {
            string query = membrosQueries.DeletarMembros;

            await using (var connection = new SqlConnection(connectionString))
            {
                var retorno = await connection.ExecuteAsync(query, new { IdMembro = id }).ConfigureAwait(false);
                return retorno > 0;
            }
        }
    }
    

}
