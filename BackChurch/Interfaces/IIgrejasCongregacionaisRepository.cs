using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IIgrejasCongregacionaisRepository
    {
        Task<bool> CriarIgrejaCongregacao(IgrejasCongregacionais igreja);
        Task<bool> AtualizarIgrejaCongregacao(IgrejasCongregacionais igreja);
        Task<bool> DeletarIgrejaCongregacao(int id);
        Task<IgrejasCongregacionais> ObterIgrejaCongregacaoPorId(int id);
        Task<IList<IgrejaCongregacionaisSemEndereco>> ObterIgrejasCongregacaos();

    }
}
