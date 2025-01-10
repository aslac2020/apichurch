using BackChurch.Domain;

namespace BackChurch.Interfaces
{
    public interface IEnderecosMembrosRepository
    {
        Task<bool> CriarEnderecosMembros(EnderecosMembros dizimos);
        Task<bool> AtualizarEnderecosMembros(EnderecosMembros dizimos);
        Task<bool> DeletarEnderecosMembros(int id);
        Task<IList<EnderecosMembros>> ObterEnderecosMembros();
        Task<EnderecosMembros> ObterEnderecosMembrosPorId(int id);
    }
}
