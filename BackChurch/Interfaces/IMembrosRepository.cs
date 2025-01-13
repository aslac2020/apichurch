using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IMembrosRepository
    {
        Task<bool> CriarMembro(Membros dizimos);
        Task<bool> AtualizarMembro(Membros dizimos);
        Task<bool> DeletarMembro(int id);
        Task<IList<Membros>> ObterMembros();
        Task<MembroCadastroCompleto> ObterMembroPorId(int id);
    }
}
