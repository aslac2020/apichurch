using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IIgrejasSetoresRepository
    {
        Task<bool> CriarIgrejaSetor(IgrejasSetores igreja);
        Task<bool> AtualizarIgrejaSetor(IgrejasSetores igreja);
        Task<bool> DeletarIgrejaSetor(int id);
        Task<IgrejasSetores> ObterIgrejaSetorPorId(int id);
        Task<IList<IgrejaSetoresSemEndereco>> ObterIgrejasSetores();

    }
}
