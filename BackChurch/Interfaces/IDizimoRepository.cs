using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IDizimoRepository
    {
        Task<bool> CriarDizimo(Dizimos dizimos);
        Task<bool> AtualizarDizimo(Dizimos dizimos);
        Task<bool> DeletarDizimo(int id);
        Task<IList<Dizimos>> ObterDizimos();
        Task<Dizimos> ObterDizimoPorId(int id);
    }
}
