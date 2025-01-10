using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IIgrejaRepository
    {
        Task<bool> CriarIgreja(Igrejas igreja);
        Task<bool> AtualizarIgreja(Igrejas igreja);
        Task<bool> DeletarIgreja(int id);
        Task<Igrejas> ObterIgrejaPorId(int id);
        Task<IList<IgrejaSemEndereco>> ObterIgrejas();

    }
}
