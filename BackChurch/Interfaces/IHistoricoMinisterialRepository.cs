using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IHistoricoMinisterialRepository
    {
        Task<bool> CriarHistoricoMinisterial(HistoricoMinisterial historicoMinisterial);
        Task<bool> AtualizarHistoricoMinisterial(HistoricoMinisterial historicoMinisterial);
        Task<bool> DeletarHistoricoMinisterial(int id);
        Task<IList<HistoricoMinisterial>> ObterHistoricoMinisterial();
        Task<HistoricoMinisterial> ObterHistoricoMinisterialPorId(int id);
    }
}
