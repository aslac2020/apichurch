using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IFrequenciaRepository
    {
        Task<bool> CriarFrequencia(Frequencia frequencia);
        Task<bool> AtualizarFrequencia(Frequencia frequencia);
        Task<bool> DeletarFrequencia(int id);
        Task<Frequencia> ObterFrequenciaPorId(int id);
        Task<IList<Frequencia>> ObterFrequencias();
    }
}
