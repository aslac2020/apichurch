using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IEventoRepository
    {
        Task<bool> CriarEvento(Eventos evento);
        Task<bool> AtualizarEvento(Eventos evento);
        Task<bool> DeletarEvento(int id);
        Task<Eventos> ObterEventoPorId(int id);
        Task<IList<Eventos>> ObterEventos(); 
    }
}
